using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.FactsetModels
{
    public class ModelFactory
    {
        public CompanyList CreateCompanyList(ff_basic_v2 company)
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

        public PagedCompanyList CreatePagedCompanyList(IEnumerable<CompanyList> companyList, int pageIndex, int pageSize)
        {
            return new PagedCompanyList()
            {
                Count = companyList.Count(),
                Data = companyList.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
        }

        public CompanySearch CreateCompanySearch(IEnumerable<Industry> industries, IEnumerable<Country> countries,
            IEnumerable<Sector> sectors, IEnumerable<SIC> sics, IEnumerable<EntityType> entityTypes)
        {
            return new CompanySearch()
            {
                Countries = countries,
                Sectors = sectors,
                EntityTypes = entityTypes,
                SICs = sics,
                Industries = industries
            };
        }

        public Industry CreateIndustries(factset_industry_map industry)
        {
            return new Industry()
            {
                IndustryCode = industry.factset_industry_code,
                IndustryDescription = industry.factset_industry_desc
            };
        }

        public Country CreateCountries(country_map country)
        {
            return new Country()
            {
                ISOCountry = country.iso_country,
                CountryDescription = country.country_desc,
                ISOCurrency = country.iso_country,
                Region = new Region()
                {
                    RegionCode = country.region_code,
                    RegionDescription = ""
                }
            };
        }

        public Region CreateRegions(region_map region)
        {
            return new Region()
            {
                RegionCode = region.region_code,
                RegionDescription = region.region_desc
            };
        }

        public Sector CreateSectors(factset_sector_map sector)
        {
            return new Sector()
            {
                SectorCode = sector.factset_sector_code,
                SectorDescription = sector.factset_sector_desc
            };
        }

        public SIC CreateSICs(sic_map sic)
        {
            return new SIC()
            {
                SICCode = sic.sic_code,
                SICDescription = sic.sic_desc
            };
        }

        public EntityType CreateEntityTypes(entity_type_map entityType)
        {
            return new EntityType()
            {
                EntityTypeCode = entityType.entity_type_code,
                EntityTypeDescription = entityType.entity_type_desc
            };
        }

    }
}
