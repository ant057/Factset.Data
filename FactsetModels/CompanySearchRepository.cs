using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Factset.Data.FactsetModels
{

    interface ICompanySearchRepository
    {
        CompanySearch GetCompanySearch();
        IEnumerable<CompanyList> GetFilteredCompanies(SearchParams searches);
    }

    public class CompanySearchRepository : ICompanySearchRepository
    {
        private FactsetEntities _db = null;
        private DbSet<ff_basic_v2> _basic = null;
        private DbSet<h_entity> _entity = null;
        private DbSet<country_map> _country_map = null;
        private DbSet<region_map> _region_map = null;
        private DbSet<factset_industry_map> _factset_industry_map = null;
        private DbSet<factset_sector_map> _factset_sector_map = null;
        private DbSet<sic_map> _sic_map = null;
        private DbSet<entity_type_map> _entity_type_map = null;
        private DbSet<h_entity_sector> _entity_sector = null;

        public CompanySearchRepository(FactsetEntities db)
        {
            _db = db;
            _basic = _db.ff_basic_v2;
            _entity = _db.h_entity;
            _country_map = _db.country_map;
            _region_map = _db.region_map;
            _factset_industry_map = _db.factset_industry_map;
            _factset_sector_map = _db.factset_sector_map;
            _sic_map = _db.sic_map;
            _entity_type_map = _db.entity_type_map;
            _entity_sector = _db.h_entity_sector;
        }

        public CompanySearch GetCompanySearch()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<country_map> GetAllCountries()
        {
            return _country_map.ToList();
        }

        public IEnumerable<region_map> GetAllRegions()
        {
            return _region_map.ToList();
        }

        public IEnumerable<factset_industry_map> GetAllIndustries()
        {
            return _factset_industry_map.ToList();
        }

        public IEnumerable<factset_sector_map> GetAllSectors()
        {
            return _factset_sector_map.ToList();
        }

        public IEnumerable<sic_map> GetAllSICodes()
        {
            return _sic_map.ToList();
        }

        public IEnumerable<entity_type_map> GetAllEntityTypes()
        {
            return _entity_type_map.ToList();
        }

        public IEnumerable<CompanyList> GetFilteredCompanies(SearchParams searches)
        {
            var results = from Basic in _basic
                          join Country in _country_map on Basic.ff_country_iso equals Country.iso_country 
                          join Entity in _entity on Basic.factset_entity_id equals Entity.factset_entity_id
                          join EntityType in _entity_type_map on Entity.entity_type equals EntityType.entity_type_code
                          join EntitySector in _entity_sector on Entity.factset_entity_id equals EntitySector.factset_entity_id
                          join SIC in _sic_map on EntitySector.primary_sic_code equals SIC.sic_code
                          join Industry in _factset_industry_map on EntitySector.industry_code equals Industry.factset_industry_code
                          join Sector in _factset_sector_map on EntitySector.sector_code equals Sector.factset_sector_code
                          orderby Basic.ff_co_name
                          select new CompanyList()
                          {
                              PermanentSecurityID = Basic.fs_perm_sec_id,
                              EntityId = Basic.factset_entity_id,
                              CountryISO = Basic.ff_country_iso,
                              LatestAnnualUpdate = Basic.fa_latest_ann_update,
                              CompanyName = Basic.ff_co_name,
                              BusinessDescriptionAbbrev = Basic.ff_bus_desc_abbrev,
                              MarketValueCurrent = Basic.ff_mkt_val_curr,
                              UniverseAmerica = Basic.universe_am,
                              UniverseAsiaPacific = Basic.universe_ap,
                              UniverseEurope = Basic.universe_eu,
                              ISOCountry = Country.iso_country,
                              CountryDescription = Country.country_desc,
                              IndustryCode = Industry.factset_industry_code,
                              IndustryDescription = Industry.factset_industry_desc,
                              SectorCode = Sector.factset_sector_code,
                              SectorDescription  = Sector.factset_sector_desc,
                              SICCode = SIC.sic_code,
                              SICDescription = SIC.sic_desc,
                              EntityTypeCode = EntityType.entity_type_code,
                              EntityTypeDescription = EntityType.entity_type_desc
                          };
            if(searches.Industries != null)
            { 
                if (searches.Industries.Length > 0)
                {
                    string[] industrySearchCrit = new string[searches.Industries.Length];
                    for (int i = 0; i < searches.Industries.Length; i++)
                    {
                        industrySearchCrit[i] = searches.Industries[i].IndustryDescription;
                    }
                    string crit = string.Join(",", industrySearchCrit);
                    results = results.Where(i => crit.IndexOf(i.IndustryDescription) > -1);
                }
            }

            if (searches.Countries != null)
            {
                if (searches.Countries.Length > 0)
                {
                    string[] countrySearchCrit = new string[searches.Countries.Length];
                    for (int i = 0; i < searches.Countries.Length; i++)
                    {
                        countrySearchCrit[i] = searches.Countries[i].CountryDescription;
                    }
                    string crit = string.Join(",", countrySearchCrit);
                    results = results.Where(i => crit.IndexOf(i.CountryDescription) > -1);
                }
            }

            if (searches.EntityTypes != null)
            {
                if (searches.EntityTypes.Length > 0)
                {
                    string[] entityTypeSearchCrit = new string[searches.EntityTypes.Length];
                    for (int i = 0; i < searches.EntityTypes.Length; i++)
                    {
                        entityTypeSearchCrit[i] = searches.EntityTypes[i].EntityTypeDescription;
                    }
                    string crit = string.Join(",", entityTypeSearchCrit);
                    results = results.Where(i => crit.IndexOf(i.EntityTypeDescription) > -1);
                }
            }

            if (searches.Sectors != null)
            {
                if (searches.Sectors.Length > 0)
                {
                    string[] sectorSearchCrit = new string[searches.Sectors.Length];
                    for (int i = 0; i < searches.Sectors.Length; i++)
                    {
                        sectorSearchCrit[i] = searches.Sectors[i].SectorDescription;
                    }
                    string crit = string.Join(",", sectorSearchCrit);
                    results = results.Where(i => crit.IndexOf(i.SectorDescription) > -1);
                }
            }

            if (searches.SicCodes != null)
            {
                if (searches.SicCodes.Length > 0)
                {
                    string[] sicSearchCrit = new string[searches.SicCodes.Length];
                    for (int i = 0; i < searches.SicCodes.Length; i++)
                    {
                        sicSearchCrit[i] = searches.SicCodes[i].SICCode.Substring(0, 4);
                    }
                    string crit = string.Join(",", sicSearchCrit);
                    results = results.Where(i => crit.IndexOf(i.SICCode) > -1);
                }
            }

            return results;
        }
    }
}