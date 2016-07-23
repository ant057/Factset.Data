using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;

namespace Factset.Data.Models
{
    interface IFinancialRepository
    {
        object GetFinancialStatements(string permSecurityId);
    }

    public class FinancialRepository : IFinancialRepository
    {
        private FactsetEntities _db = null;

        private DbSet<ff_basic_v2> _basic = null;
        private DbSet<ff_gen_ind_map> _gen_ind_map = null;
        private DbSet<ff_balance_model> _bal_mod = null;
        private DbSet<ff_balance_model_rpt_map> _bal_mod_rpt_map = null;
        private DbSet<ff_balance_model_ind> _bal_mod_ind = null;

        private DbSet<ff_basic_af_v2> _basic_annual = null;

        public FinancialRepository(FactsetEntities db)
        {
            _db = db;
            _basic_annual = _db.ff_basic_af_v2;
        }

        public List<object> GetFinancialStatements(string permSecurityId)
        {
            var results = _basic_annual
                .Where(c => c.fs_perm_sec_id == permSecurityId)
                .Select("new(ff_sales as Sales)");
            return results.ToListAsync();
        }

        private IEnumerable<BalanceModel> GetBalanceModel(string permSecurityId)
        {
            IEnumerable<BalanceModel> balanceModel = null;
            var query = from basic in _basic
                        join general in _gen_ind_map on basic.ff_gen_ind equals general.ff_gen_ind
                        join balancemodelrptmap in _bal_mod_rpt_map on basic.ff_gen_ind equals balancemodelrptmap.ff_gen_ind
                        join balancemodel in _bal_mod on balancemodelrptmap.report_code equals balancemodel.report_code
                        join balancemodelind in _bal_mod_ind on balancemodel.field_name equals balancemodelind.field_name
                        where basic.fs_perm_sec_id == permSecurityId
                        select new BalanceModel()
                        {
                            ReportCode = balancemodel.report_code,
                            DisplayOrder = balancemodel.display_order,
                            DisplayLevel = balancemodel.display_level,
                            Description = balancemodel.description,
                            FieldName = balancemodel.field_name,
                            Negative = balancemodel.negative
                        };

            balanceModel = query.ToList();
            return balanceModel;
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