using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    public class CompanySearch
    {
        public string fs_perm_sec_id { get; set; }
        public string factset_entity_id { get; set; }
        public string ff_country_iso { get; set; }
        public decimal? fa_latest_ann_update { get; set; }
        public string ff_co_name { get; set; }
        public string ff_bus_desc_abbrev { get; set; }
        public double? ff_mkt_val_curr { get; set; }
    }
}