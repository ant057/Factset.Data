using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    public class CompanySearch
    {
        public Country Country { get; set; }
        public Industry Industry { get; set; }
        public Sector Sector { get; set; }
        public SIC SIC { get; set; }
        public EntityType EntityType { get; set; }
    }

    public class CompanyList
    {
        public string PermanentSecurityID { get; set; }
        public string EntityId { get; set; }
        public string CountryISO { get; set; }
        public decimal? LatestAnnualUpdate { get; set; }
        public string CompanyName { get; set; }
        public string BusinessDescriptionAbbrev { get; set; }
        public double? MarketValueCurrent { get; set; }

        //search criteria
        public bool UniverseAmerica { get; set; }
        public bool UniverseEurope { get; set; }
        public bool UniverseAsiaPacific { get; set; }

        public Country Country { get; set; }
        public Industry Industry { get; set; }
        public Sector Sector { get; set; }
        public SIC SIC { get; set; }
        public EntityType EntityType { get; set; }
    }

    public class Universe
    {
        public bool universe_am { get; set; }
        public bool universe_eu { get; set; }
        public bool universe_ap { get; set; }
    }

    public class Country
    {
        public string country_desc { get; set; }
        public string iso_currency { get; set; }
        public Region region { get; set; }
    }

    public class Region
    {
        public char region_code { get; set; }
        public string region_desc { get; set; }
    }

    public class Industry
    {
        public string factset_industry_code { get; set; }
        public string factset_industry_desc { get; set; }
    }

    public class Sector
    {
        public string factset_sector_code { get; set; }
        public string factset_sector_desc { get; set; }
    }

    public class SIC
    {
        public string sic_code { get; set; }
        public string sic_desc { get; set; }
    }

    public class EntityType
    {
        public string entity_type_code { get; set; }
        public string entity_type_desc { get; set; }
    }
}