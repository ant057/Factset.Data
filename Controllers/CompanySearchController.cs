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
    public class CompanySearchController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private ModelFactory _modelFactory;

        public CompanySearchController()
        {
            _modelFactory = new ModelFactory();
        }

        //api/CompanySearch/SearchCompanies
        [Route("api/CompanySearch/SearchCompanies")]
        [HttpGet]
        public IEnumerable<CompanyList> SearchCompanies()
        {
            var results = _unitOfWork.CompanyRespository.GetAll()
                .OrderBy(c => c.ff_co_name)
                .Take(100)
                .ToList()
                .Select(c => _modelFactory.Create(c));

            return results;
        }

        //api/CompanySearch/GetAll
        [Route("api/CompanySearch/GetAll")]
        [HttpGet]
        public IEnumerable<CompanyList> GetAll()
        {
            var results = _unitOfWork.CompanyRespository.GetAll()
                .OrderBy(c => c.ff_co_name)
                .ToList()
                .Select(c => _modelFactory.Create(c));

            return results;
        }
    }
}
