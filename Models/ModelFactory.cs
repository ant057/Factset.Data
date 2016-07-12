using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    public class ModelFactory
    {
        public CompanySearch Create(ff_basic_v2 company)
        {
            return new CompanySearch()
            {
                fs_perm_sec_id = company.fs_perm_sec_id,
                factset_entity_id = company.factset_entity_id,
                ff_country_iso = company.ff_country_iso,
                fa_latest_ann_update = company.fa_latest_ann_update,
                ff_co_name = company.ff_co_name,
                ff_bus_desc_abbrev = company.ff_bus_desc_abbrev,
                ff_mkt_val_curr = company.ff_mkt_val_curr
            };
        }
    }
}
