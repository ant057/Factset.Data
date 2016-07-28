using Factset.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Factset.Data.Controllers
{
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private ModelFactory _modelFactory;

        public CompanyController()
        {
            _modelFactory = new ModelFactory();
        }

        //api/Company/GetCompany/12345US
        [Route("GetCompany/{permSecurityId}")]
        [HttpGet]
        public Company GetCompany(string permSecurityId)
        {
            var results = _unitOfWork.CompanyDetailRespository.GetCompany(permSecurityId);
            var financial = _unitOfWork.FinancialRepository.GetFinancialStatements(permSecurityId);

            results.FinancialStatements = financial;
            return results;
        }
    }
}
