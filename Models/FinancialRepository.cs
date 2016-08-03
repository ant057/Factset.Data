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

        //annual
        private DbSet<ff_basic_af_v2> _basic_annual = null;
        private DbSet<ff_basic_der_af_v2> _basic_annual_der = null;
        private DbSet<ff_advanced_af_v2> _advanced_annual = null;
        private DbSet<ff_advanced_der_af_v2> _advanced_annual_der = null;

        //quarterly
        private DbSet<ff_basic_qf_v2> _basic_quarter = null;
        private DbSet<ff_basic_der_qf_v2> _basic_quarter_der = null;
        private DbSet<ff_advanced_qf_v2> _advanced_quarter = null;
        private DbSet<ff_advanced_der_qf_v2> _advanced_quarter_der = null;

        //LTM
        private DbSet<ff_basic_ltm_v2> _basic_ltm = null;
        private DbSet<ff_basic_der_ltm_v2> _basic_ltm_der = null;
        private DbSet<ff_advanced_ltm_v2> _advanced_ltm = null;
        private DbSet<ff_advanced_der_ltm_v2> _advanced_ltm_der = null;

        //SemiAnnual
        private DbSet<ff_basic_saf_v2> _basic_semiannual = null;
        private DbSet<ff_basic_der_saf_v2> _basic_semiannual_der = null;
        private DbSet<ff_advanced_saf_v2> _advanced_semiannual = null;
        private DbSet<ff_advanced_der_saf_v2> _advanced_semiannual_der = null;

        public FinancialRepository(FactsetEntities db)
        {
            _db = db;

            _basic = _db.ff_basic_v2;
            _basic_annual_der = _db.ff_basic_der_af_v2;
            _advanced_annual = _db.ff_advanced_af_v2;
            _advanced_annual_der = _db.ff_advanced_der_af_v2;

            _basic_quarter = _db.ff_basic_qf_v2;
            _basic_quarter_der = _db.ff_basic_der_qf_v2;
            _advanced_quarter = _db.ff_advanced_qf_v2;
            _advanced_quarter_der = _db.ff_advanced_der_qf_v2;

            _basic_ltm = _db.ff_basic_ltm_v2;
            _basic_ltm_der = _db.ff_basic_der_ltm_v2;
            _advanced_ltm = _db.ff_advanced_ltm_v2;
            _advanced_ltm_der = _db.ff_advanced_der_ltm_v2;

            _basic_semiannual = _db.ff_basic_saf_v2;
            _basic_semiannual_der = _db.ff_basic_der_saf_v2;
            _advanced_semiannual = _db.ff_advanced_saf_v2;
            _advanced_semiannual_der = _db.ff_advanced_der_saf_v2;

            _basic_annual = _db.ff_basic_af_v2;
            _gen_ind_map = _db.ff_gen_ind_map;
            _bal_mod = _db.ff_balance_model;
            _bal_mod_rpt_map = _db.ff_balance_model_rpt_map;
            _bal_mod_ind = _db.ff_balance_model_ind;
            _metadata = _db.ff_metadata;
        }

        private IEnumerable<FinancialDetail> Get4YrAnnualFinancialStatements(string permSecurityId)
        {
            List<FinancialDetail> financials = new List<FinancialDetail>();

            var results = (from BasicAnnual in _basic_annual
                          join BasicAnnualDerived in _basic_annual_der on BasicAnnual.fs_perm_sec_id equals BasicAnnualDerived.fs_perm_sec_id //into ALLCOLUMNS
                          join AdvancedAnnual in _advanced_annual on BasicAnnual.fs_perm_sec_id equals AdvancedAnnual.fs_perm_sec_id
                          join AdvancedAnnualDerived in _advanced_annual on BasicAnnual.fs_perm_sec_id equals AdvancedAnnualDerived.fs_perm_sec_id
                          orderby BasicAnnual.date descending
                          where BasicAnnual.fs_perm_sec_id == permSecurityId
                          && BasicAnnual.date == BasicAnnualDerived.date
                          && BasicAnnual.date == AdvancedAnnual.date
                          && BasicAnnual.date == AdvancedAnnualDerived.date
                          && BasicAnnual.date >= DbFunctions.AddYears(DateTime.Now, -5)
                          select new { BasicAnnual, BasicAnnualDerived, AdvancedAnnual, AdvancedAnnualDerived }).Take(4);
                          
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
                                balanceModelItem.Value = float.Parse(itemValue.ToString());
                            }
                        }
                    }
                }
                financialDetail.FinancialStatements = balanceModel;
                financials.Add(financialDetail);
            }

            return financials;
        }

        private IEnumerable<FinancialDetail> Get4QuarterlyFinancialStatements(string permSecurityId)
        {
            List<FinancialDetail> financials = new List<FinancialDetail>();

            var results = (from BasicQuarter in _basic_quarter
                          join BasicQuarterDerived in _basic_quarter_der on BasicQuarter.fs_perm_sec_id equals BasicQuarterDerived.fs_perm_sec_id //into ALLCOLUMNS
                          join AdvancedQuarter in _advanced_quarter on BasicQuarter.fs_perm_sec_id equals AdvancedQuarter.fs_perm_sec_id
                          join AdvancedQuarterDerived in _advanced_quarter_der on BasicQuarter.fs_perm_sec_id equals AdvancedQuarterDerived.fs_perm_sec_id
                          orderby BasicQuarter.date descending
                          where BasicQuarter.fs_perm_sec_id == permSecurityId
                          && BasicQuarter.date == BasicQuarterDerived.date
                          && BasicQuarter.date == AdvancedQuarter.date
                          && BasicQuarter.date == AdvancedQuarterDerived.date
                          && BasicQuarter.date >= DbFunctions.AddMonths(DateTime.Now, -15)
                          select new { BasicQuarter, BasicQuarterDerived, AdvancedQuarter, AdvancedQuarterDerived }).Take(4);

            //var resultsProps = results.GetType().GetProperties();
            foreach (var item in results)
            {
                IEnumerable<BalanceModel> balanceModel = GetBalanceModel(permSecurityId);
                FinancialDetail financialDetail = new FinancialDetail();
                financialDetail.Date = item.BasicQuarter.date;
                financialDetail.Currency = item.BasicQuarter.currency;
                financialDetail.AdjustedDate = item.BasicQuarter.adjdate;

                foreach (var balanceModelItem in balanceModel)
                {
                    var itemPropsBasic = item.BasicQuarter.GetType().GetProperties();
                    var itemPropsBasicDerived = item.BasicQuarterDerived.GetType().GetProperties();
                    var itemPropsAdvanced = item.AdvancedQuarter.GetType().GetProperties();
                    var itemPropsAdvancedDerived = item.AdvancedQuarterDerived.GetType().GetProperties();

                    IEnumerable<PropertyInfo> itemProps = CombineArrays(itemPropsBasic,
                        itemPropsBasicDerived, itemPropsAdvanced, itemPropsAdvancedDerived);

                    foreach (var itemProp in itemProps)
                    {
                        if (itemProp.Name == balanceModelItem.FieldName)
                        {
                            var method = itemProp.GetGetMethod();
                            object itemValue = null;
                            if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_qf_v2"))
                                itemValue = method.Invoke(item.BasicQuarter, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_der_qf_v2"))
                                itemValue = method.Invoke(item.BasicQuarterDerived, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_qf_v2"))
                                itemValue = method.Invoke(item.AdvancedQuarter, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_der_qf_v2"))
                                itemValue = method.Invoke(item.AdvancedQuarterDerived, null);

                            if (itemValue != null)
                            {
                                balanceModelItem.Value = float.Parse(itemValue.ToString());
                            }
                        }
                    }
                }
                financialDetail.FinancialStatements = balanceModel;
                financials.Add(financialDetail);
            }

            return financials;
        }

        private IEnumerable<FinancialDetail> Get4LTMFinancialStatements(string permSecurityId)
        {
            List<FinancialDetail> financials = new List<FinancialDetail>();

            var results = (from BasicLTM in _basic_ltm
                          join BasicLTMDerived in _basic_ltm_der on BasicLTM.fs_perm_sec_id equals BasicLTMDerived.fs_perm_sec_id //into ALLCOLUMNS
                          join AdvancedLTM in _advanced_ltm on BasicLTM.fs_perm_sec_id equals AdvancedLTM.fs_perm_sec_id
                          join AdvancedLTMDerived in _advanced_ltm_der on BasicLTM.fs_perm_sec_id equals AdvancedLTMDerived.fs_perm_sec_id
                          orderby BasicLTM.date descending
                          where BasicLTM.fs_perm_sec_id == permSecurityId
                          && BasicLTM.date == BasicLTMDerived.date
                          && BasicLTM.date == AdvancedLTM.date
                          && BasicLTM.date == AdvancedLTMDerived.date
                          && BasicLTM.date >= DbFunctions.AddMonths(DateTime.Now, -15)
                          select new { BasicLTM, BasicLTMDerived, AdvancedLTM, AdvancedLTMDerived }).Take(4);

            //var resultsProps = results.GetType().GetProperties();
            foreach (var item in results)
            {
                IEnumerable<BalanceModel> balanceModel = GetBalanceModel(permSecurityId);
                FinancialDetail financialDetail = new FinancialDetail();
                financialDetail.Date = item.BasicLTM.date;
                financialDetail.Currency = item.BasicLTM.currency;
                financialDetail.AdjustedDate = item.BasicLTM.adjdate;

                foreach (var balanceModelItem in balanceModel)
                {
                    var itemPropsBasic = item.BasicLTM.GetType().GetProperties();
                    var itemPropsBasicDerived = item.BasicLTMDerived.GetType().GetProperties();
                    var itemPropsAdvanced = item.AdvancedLTM.GetType().GetProperties();
                    var itemPropsAdvancedDerived = item.AdvancedLTMDerived.GetType().GetProperties();

                    IEnumerable<PropertyInfo> itemProps = CombineArrays(itemPropsBasic,
                        itemPropsBasicDerived, itemPropsAdvanced, itemPropsAdvancedDerived);

                    foreach (var itemProp in itemProps)
                    {
                        if (itemProp.Name == balanceModelItem.FieldName)
                        {
                            var method = itemProp.GetGetMethod();
                            object itemValue = null;
                            if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_ltm_v2"))
                                itemValue = method.Invoke(item.BasicLTM, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_der_ltm_v2"))
                                itemValue = method.Invoke(item.BasicLTMDerived, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_ltm_v2"))
                                itemValue = method.Invoke(item.AdvancedLTM, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_der_ltm_v2"))
                                itemValue = method.Invoke(item.AdvancedLTMDerived, null);

                            if (itemValue != null)
                            {
                                balanceModelItem.Value = float.Parse(itemValue.ToString());
                            }
                        }
                    }
                }
                financialDetail.FinancialStatements = balanceModel;
                financials.Add(financialDetail);
            }

            return financials;
        }

        private IEnumerable<FinancialDetail> Get4SemiAnnualFinancialStatements(string permSecurityId)
        {
            List<FinancialDetail> financials = new List<FinancialDetail>();

            var results = (from BasicSemiAnnual in _basic_semiannual
                          join BasicSemiAnnualDerived in _basic_semiannual_der on BasicSemiAnnual.fs_perm_sec_id equals BasicSemiAnnualDerived.fs_perm_sec_id //into ALLCOLUMNS
                          join AdvancedSemiAnnual in _advanced_semiannual on BasicSemiAnnual.fs_perm_sec_id equals AdvancedSemiAnnual.fs_perm_sec_id
                          join AdvancedSemiAnnualDerived in _advanced_semiannual_der on BasicSemiAnnual.fs_perm_sec_id equals AdvancedSemiAnnualDerived.fs_perm_sec_id
                          orderby BasicSemiAnnual.date descending
                          where BasicSemiAnnual.fs_perm_sec_id == permSecurityId
                          && BasicSemiAnnual.date == BasicSemiAnnualDerived.date
                          && BasicSemiAnnual.date == AdvancedSemiAnnual.date
                          && BasicSemiAnnual.date == AdvancedSemiAnnualDerived.date
                          && BasicSemiAnnual.date >= DbFunctions.AddMonths(DateTime.Now, -15)
                          select new { BasicSemiAnnual, BasicSemiAnnualDerived, AdvancedSemiAnnual, AdvancedSemiAnnualDerived }).Take(4);

            //var resultsProps = results.GetType().GetProperties();
            foreach (var item in results)
            {
                IEnumerable<BalanceModel> balanceModel = GetBalanceModel(permSecurityId);
                FinancialDetail financialDetail = new FinancialDetail();
                financialDetail.Date = item.BasicSemiAnnual.date;
                financialDetail.Currency = item.BasicSemiAnnual.currency;
                financialDetail.AdjustedDate = item.BasicSemiAnnual.adjdate;

                foreach (var balanceModelItem in balanceModel)
                {
                    var itemPropsBasic = item.BasicSemiAnnual.GetType().GetProperties();
                    var itemPropsBasicDerived = item.BasicSemiAnnualDerived.GetType().GetProperties();
                    var itemPropsAdvanced = item.AdvancedSemiAnnual.GetType().GetProperties();
                    var itemPropsAdvancedDerived = item.AdvancedSemiAnnualDerived.GetType().GetProperties();

                    IEnumerable<PropertyInfo> itemProps = CombineArrays(itemPropsBasic,
                        itemPropsBasicDerived, itemPropsAdvanced, itemPropsAdvancedDerived);

                    foreach (var itemProp in itemProps)
                    {
                        if (itemProp.Name == balanceModelItem.FieldName)
                        {
                            var method = itemProp.GetGetMethod();
                            object itemValue = null;
                            if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_saf_v2"))
                                itemValue = method.Invoke(item.BasicSemiAnnual, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_basic_der_saf_v2"))
                                itemValue = method.Invoke(item.BasicSemiAnnualDerived, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_saf_v2"))
                                itemValue = method.Invoke(item.AdvancedSemiAnnual, null);
                            else if (itemProp.DeclaringType.FullName.Equals("Factset.Data.Domain.ff_advanced_der_saf_v2"))
                                itemValue = method.Invoke(item.AdvancedSemiAnnualDerived, null);

                            if (itemValue != null)
                            {
                                balanceModelItem.Value = float.Parse(itemValue.ToString());
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
            companyFinancials.AnnualFinancialStatements = Get4YrAnnualFinancialStatements(permSecurityId);
            companyFinancials.QuarterlyFinancialStatements = Get4QuarterlyFinancialStatements(permSecurityId);
            companyFinancials.SemiAnnualFinancialStatements = Get4SemiAnnualFinancialStatements(permSecurityId);
            companyFinancials.LTMFinancialStatements = Get4LTMFinancialStatements(permSecurityId);

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