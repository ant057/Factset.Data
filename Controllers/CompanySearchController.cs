using Factset.Data.Domain;
using Factset.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Factset.Data.Controllers
{
    [RoutePrefix("api/CompanySearch")]
    public class CompanySearchController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private ModelFactory _modelFactory;

        public CompanySearchController()
        {
            _modelFactory = new ModelFactory();
        }

        //api/CompanySearch/GetCompanySearch
        [Route("GetCompanySearch")]
        [HttpGet]
        public CompanySearch GetCompanySearch()
        {
            var industries = _unitOfWork.CompanySearchRepository.GetAllIndustries()
                .OrderBy(i => i.factset_industry_desc)
                .ToList()
                .Select(i => _modelFactory.CreateIndustries(i));

            var countries = _unitOfWork.CompanySearchRepository.GetAllCountries()
                .OrderBy(c => c.iso_country)
                .ToList()
                .Select(c => _modelFactory.CreateCountries(c));

            var sectors = _unitOfWork.CompanySearchRepository.GetAllSectors()
                .OrderBy(s => s.factset_sector_desc)
                .ToList()
                .Select(s => _modelFactory.CreateSectors(s));

            var sics = _unitOfWork.CompanySearchRepository.GetAllSICodes()
                .OrderBy(a => a.sic_code)
                .ToList()
                .Select(a => _modelFactory.CreateSICs(a));

            var entityTypes = _unitOfWork.CompanySearchRepository.GetAllEntityTypes()
                .OrderBy(e => e.entity_type_desc)
                .ToList()
                .Select(e => _modelFactory.CreateEntityTypes(e));

            return _modelFactory.CreateCompanySearch(industries, countries, sectors, sics, entityTypes);
        }

        //api/CompanySearch/GetAllCompaniesPaged/1/50
        [Route("GetAllCompaniesPaged/{pageIndex:int}/{pageSize:int}")]
        [HttpGet]
        public PagedCompanyList GetAllCompaniesPaged(int pageIndex = 1, int pageSize = 50)
        {
            var results = _unitOfWork.CompanyRepository.GetAll()
                .OrderBy(c => c.ff_co_name)
                .ToList()
                .Select(c => _modelFactory.CreateCompanyList(c));

            return _modelFactory.CreatePagedCompanyList(results, pageIndex, pageSize);
        }

        //api/CompanySearch/GetAllCompanies
        [Route("GetAllCompanies")]
        [HttpGet]
        public IEnumerable<CompanyList> GetAllCompanies()
        {
            var results = _unitOfWork.CompanyRepository.GetAll()
                .OrderBy(c => c.ff_co_name)
                .ToList()
                .Select(c => _modelFactory.CreateCompanyList(c));

            return results;
        }

    }
}
