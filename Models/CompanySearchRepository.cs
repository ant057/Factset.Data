using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{

    interface ICompanySearchRepository
    {
        CompanySearch GetCompanySearch();
    }

    public class CompanySearchRepository : ICompanySearchRepository
    {
        private FactsetEntities _db = null;
        private DbSet<country_map> _country_map = null;
        private DbSet<region_map> _region_map = null;
        private DbSet<factset_industry_map> _factset_industry_map = null;
        private DbSet<factset_sector_map> _factset_sector_map = null;
        private DbSet<sic_map> _sic_map = null;
        private DbSet<entity_type_map> _entity_type_map = null;

        public CompanySearchRepository(FactsetEntities db)
        {
            _db = db;
            _country_map = _db.country_map;
            _region_map = _db.region_map;
            _factset_industry_map = _db.factset_industry_map;
            _factset_sector_map = _db.factset_sector_map;
            _sic_map = _db.sic_map;
            _entity_type_map = _db.entity_type_map;
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
    }
}