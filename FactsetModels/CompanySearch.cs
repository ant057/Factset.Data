using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.FactsetModels
{
    public class CompanySearch
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Industry> Industries { get; set; }
        public IEnumerable<Sector> Sectors { get; set; }
        public IEnumerable<SIC> SICs { get; set; }
        public IEnumerable<EntityType> EntityTypes { get; set; }
        public Universe Universe { get; set; }
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
        public short UniverseAmerica { get; set; }
        public short UniverseEurope { get; set; }
        public short UniverseAsiaPacific { get; set; }

        public string ISOCountry { get; set; }
        public string CountryDescription { get; set; }

        public string IndustryCode { get; set; }
        public string IndustryDescription { get; set; }

        public string SectorCode { get; set; }
        public string SectorDescription { get; set; }

        public string SICCode { get; set; }
        public string SICDescription { get; set; }

        public string EntityTypeCode { get; set; }
        public string EntityTypeDescription { get; set; }

    }

    public class PagedCompanyList
    {
        public IEnumerable<CompanyList> Data { get; set; }
        public int Count { get; set; }
    }

    public class Universe
    {
        public bool AmericaUniverse { get; set; }
        public bool EuropeUniverse { get; set; }
        public bool AsiaPacificUniverse { get; set; }
    }

    public class Country
    {
        public string ISOCountry { get; set; }
        public string CountryDescription { get; set; }
        public string ISOCurrency { get; set; }
        public Region Region { get; set; }
    }

    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionDescription { get; set; }
    }

    public class Industry
    {
        public string IndustryCode { get; set; }
        public string IndustryDescription { get; set; }
    }

    public class Sector
    {
        public string SectorCode { get; set; }
        public string SectorDescription { get; set; }
    }

    public class SIC
    {
        public string SICCode { get; set; }
        public string SICDescription { get; set; }
    }

    public class EntityType
    {
        public string EntityTypeCode { get; set; }
        public string EntityTypeDescription { get; set; }
    }

    public class SearchParams
    {
        public EntityType[] EntityTypes { get; set; }
        public SIC[] SicCodes { get; set; }
        public Sector[] Sectors { get; set; }
        public Country[] Countries { get; set; }
        public Industry[] Industries { get; set; }

        public bool AmericaUniverse { get; set; }
        public bool EuropeUniverse { get; set; }
        public bool AsiaPacificUniverse { get; set; }
    }

}