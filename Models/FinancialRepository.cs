using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace Factset.Data.Models
{
    interface IFinancialRepository
    {
        Financial GetFinancialStatements(string permSecurityId);
        //IEnumerable<BalanceModel> GetBalanceModel(string permSecurityId);
    }

    public class FinancialRepository : IFinancialRepository
    {
        private FactsetEntities _db = null;

        private DbSet<ff_basic_v2> _basic = null;
        private DbSet<ff_gen_ind_map> _gen_ind_map = null;
        private DbSet<ff_balance_model> _bal_mod = null;
        private DbSet<ff_balance_model_rpt_map> _bal_mod_rpt_map = null;
        private DbSet<ff_balance_model_ind> _bal_mod_ind = null;
        private DbSet<ff_metadata> _metadata = null;

        private DbSet<ff_basic_af_v2> _basic_annual = null;
        private DbSet<ff_basic_der_af_v2> _basic_annual_der = null;

        private DbSet<ff_advanced_af_v2> _advanced_annual = null;
        private DbSet<ff_advanced_der_af_v2> _advanced_annual_der = null;

        public FinancialRepository(FactsetEntities db)
        {
            _db = db;

            _basic = _db.ff_basic_v2;
            _basic_annual_der = _db.ff_basic_der_af_v2;
            _advanced_annual = _db.ff_advanced_af_v2;
            _advanced_annual_der = _db.ff_advanced_der_af_v2;

            _basic_annual = _db.ff_basic_af_v2;
            _gen_ind_map = _db.ff_gen_ind_map;
            _bal_mod = _db.ff_balance_model;
            _bal_mod_rpt_map = _db.ff_balance_model_rpt_map;
            _bal_mod_ind = _db.ff_balance_model_ind;
            _metadata = _db.ff_metadata;
        }

        private IEnumerable<FinancialDetail> Get5YrAnnualFinancialStatements(string permSecurityId)
        {
            List<FinancialDetail> financials = new List<FinancialDetail>();

            var results = from BasicAnnual in _basic_annual
                          join BasicAnnualDerived in _basic_annual_der on BasicAnnual.fs_perm_sec_id equals BasicAnnualDerived.fs_perm_sec_id //into ALLCOLUMNS
                          join AdvancedAnnual in _advanced_annual on BasicAnnual.fs_perm_sec_id equals AdvancedAnnual.fs_perm_sec_id
                          join AdvancedAnnualDerived in _advanced_annual on BasicAnnual.fs_perm_sec_id equals AdvancedAnnualDerived.fs_perm_sec_id
                          where BasicAnnual.fs_perm_sec_id == permSecurityId
                          && BasicAnnual.date == BasicAnnualDerived.date
                          && BasicAnnual.date == AdvancedAnnual.date
                          && BasicAnnual.date == AdvancedAnnualDerived.date
                          && BasicAnnual.date >= DbFunctions.AddYears(DateTime.Now, -3)
                          select new { BasicAnnual, BasicAnnualDerived, AdvancedAnnual, AdvancedAnnualDerived };
                          
            //var resultsProps = results.GetType().GetProperties();
            foreach (var item in results)
            {
                IEnumerable<BalanceModel> balanceModel = GetBalanceModel(permSecurityId);
                FinancialDetail financialDetail = new FinancialDetail();
                financialDetail.Date = item.BasicAnnual.date;
                financialDetail.Currency = item.BasicAnnual.currency;
                financialDetail.AdjustedDate = item.BasicAnnual.adjdate;

                foreach (var balanceModelItem in balanceModel)
                {
                    var itemPropsBasic = item.BasicAnnual.GetType().GetProperties();
                    var itemPropsBasicDerived = item.BasicAnnualDerived.GetType().GetProperties();
                    var itemPropsAdvanced = item.AdvancedAnnual.GetType().GetProperties();
                    var itemPropsAdvancedDerived = item.AdvancedAnnualDerived.GetType().GetProperties();

                    IEnumerable<PropertyInfo> itemProps = CombineArrays(itemPropsBasic, 
                        itemPropsBasicDerived, itemPropsAdvanced, itemPropsAdvancedDerived);

                    foreach (var itemProp in itemProps)
                    {
                        if (itemProp.Name == balanceModelItem.FieldName)
                        {
                            var method = itemProp.GetGetMethod();
                            object itemValue = null;
                            if(itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_af_v2"))
                                itemValue = method.Invoke(item.BasicAnnual, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_der_af_v2"))
                                itemValue = method.Invoke(item.BasicAnnualDerived, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_af_v2"))
                                itemValue = method.Invoke(item.AdvancedAnnual, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_der_af_v2"))
                                itemValue = method.Invoke(item.AdvancedAnnualDerived, null);

                            if (itemValue != null)
                            {
                                balanceModelItem.Value = itemValue.ToString();
                            }
                        }
                    }
                }
                financialDetail.FinancialStatements = balanceModel;
                financials.Add(financialDetail);
            }

            return financials;
        }

        IEnumerable<PropertyInfo> CombineArrays(params object[] arrays)
        {
            foreach (object[] arr in arrays)
            {
                foreach (object obj in arr)
                {
                    yield return (PropertyInfo)obj;
                }
            }
        }

        private IEnumerable<BalanceModel> GetBalanceModel(string permSecurityId)
        {
            IEnumerable<BalanceModel> balanceModel = null;
            try
            {
                var query = from basic in _basic
                            join general in _gen_ind_map on basic.ff_gen_ind equals general.ff_gen_ind
                            join balancemodelrptmap in _bal_mod_rpt_map on basic.ff_gen_ind equals balancemodelrptmap.ff_gen_ind
                            join balancemodel in _bal_mod on balancemodelrptmap.report_code equals balancemodel.report_code
                            join balancemodelind in _bal_mod_ind on balancemodel.field_name equals balancemodelind.field_name
                            where basic.fs_perm_sec_id == permSecurityId
                            orderby balancemodel.display_order
                            select new BalanceModel()
                            {
                                ReportCode = balancemodel.report_code,
                                DisplayOrder = balancemodel.display_order,
                                DisplayLevel = balancemodel.display_level,
                                Description = balancemodel.description,
                                FieldName = balancemodel.field_name,
                                Negative = balancemodel.negative,
                                Annual = balancemodelind.ann,
                                Quarterly = balancemodelind.qtr,
                                SemiAnnual = balancemodelind.semi,
                                LTM = balancemodelind.ltm
                            };

                balanceModel = query.ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return balanceModel;
        }

        public Financial GetFinancialStatements(string permSecurityId)
        {
            Financial companyFinancials = new Financial();
            companyFinancials.PermanentSecurityID = permSecurityId;
            companyFinancials.AnnualFinancialStatements = Get5YrAnnualFinancialStatements(permSecurityId);

            return companyFinancials;
        }

        //public List<object> ParseTable()
        //{
        //    List<object> retVal = new List<object>();
        //    foreach (object prop_loopVariable in _db.ff_basic_af_v2.GetType().GetProperties())
        //    {
        //        var prop = prop_loopVariable;
        //        retVal.Add(prop);
        //    }
        //    return retVal.ToArray();
        //}
    }
}