using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    public class ModelFactory
    {
        public CompanyList Create(ff_basic_v2 company)
        {
            return new CompanyList()
            {
                PermanentSecurityID = company.fs_perm_sec_id,
                EntityId = company.factset_entity_id,
                CountryISO = company.ff_country_iso,
                LatestAnnualUpdate = company.fa_latest_ann_update,
                CompanyName = company.ff_co_name,
                BusinessDescriptionAbbrev = company.ff_bus_desc_abbrev,
                MarketValueCurrent = company.ff_mkt_val_curr
            };
        }

        public PagedCompanyList Create(IEnumerable<CompanyList> companyList)
        {
            return new PagedCompanyList()
            {
                Count = companyList.Count(),
                Data = companyList
            };
        }
    }
}
