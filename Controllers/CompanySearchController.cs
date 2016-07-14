using Factset.Data.Domain;
using Factset.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        //api/CompanySearch/GetAllCompaniesPaged/1/50
        [Route("GetAllCompaniesPaged/{pageIndex:int}/{pageSize:int}")]
        [HttpGet]
        public PagedCompanyList GetAllCompaniesPaged(int pageIndex = 1, int pageSize = 200)
        {
            var results = _unitOfWork.CompanyRespository.GetAll()
                .OrderBy(c => c.ff_co_name)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToList()
                .Select(c => _modelFactory.Create(c));

            return _modelFactory.Create(results);
        }

        //api/CompanySearch/GetAllCompanies
        [Route("GetAllCompanies")]
        [HttpGet]
        public IEnumerable<CompanyList> GetAllCompanies()
        {
            var results = _unitOfWork.CompanyRespository.GetAll()
                .OrderBy(c => c.ff_co_name)
                .ToList()
                .Select(c => _modelFactory.Create(c));

            return results;
        }
    }
}
