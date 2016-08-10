using Factset.Data.ArgoSuretyModels;
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
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private ArgoSuretyUnitOfWork _anchorUnitOfWork = new ArgoSuretyUnitOfWork();
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
            AnchorAccount companyAccount = new AnchorAccount();

            var anchorFactsetLink = _anchorUnitOfWork.AccountFactsetLinkRepository.GetAll()
                .Where(a => a.fs_perm_sec_id == permSecurityId)
                .FirstOrDefault();
            
            if(anchorFactsetLink != null)
            {
                var account = _anchorUnitOfWork.AccountRepository.Get(int.Parse(anchorFactsetLink.AccountNumber));
                if (account != null)
                {
                    companyAccount.AccountNumber = int.Parse(account.AccountNumber.ToString());
                }
                results.AnchorAccount = companyAccount;
            }

            //results.FinancialStatements = financial;
            return results;
        }

        [Route("GetCompanyFinancials/{permSecurityId}")]
        [HttpGet]
        public Financial GetCompanyFinancials(string permSecurityId)
        {
            var financial = _unitOfWork.FinancialRepository.GetFinancialStatements(permSecurityId);
            return financial;
        }

        //api/Company/AddAccount/12345US
        [Route("AddAccount/{permSecurityId}")]
        [HttpPost]
        public AnchorAccount AddAccount(string permSecurityId)
        {
            //try
            //{
                var company = _unitOfWork.CompanyDetailRespository.GetCompany(permSecurityId);
                ArgAMS_AccountFactsetSecurity link = new ArgAMS_AccountFactsetSecurity();
                ArgAMS_Account account = new ArgAMS_Account();
                ArgAMS_Principal principal = new ArgAMS_Principal();
                principal.PrincipalName = company.CompanyName;
                principal.Address = company.Street1;
                principal.Address1 = company.Street2;
                principal.Address2 = company.Street3;
                principal.City = company.City;
                principal.State = company.State;
                principal.Zip = company.ZipCode;
                principal.Country = "";
                principal.PrinipalTypeID = 0;
                principal.ForeignOwned = false;
                principal.PublicTraded = string.IsNullOrEmpty(company.Ticker) ? false : true;
                principal.ExchangeID = 0;
                principal.Confidentiality = false;
                principal.ConfidentialityDate = new DateTime(1900, 01, 01);
                principal.Babkruptcy = false;
                principal.BankruptcyDate = new DateTime(1900, 01, 01);
                principal.WatchList = false;
                principal.WatchListDate = new DateTime(1900, 01, 01);
                principal.Collateral = false;
                principal.CollateralDate = new DateTime(1900, 01, 01);
                //var sic = _anchorUnitOfWork.SICRepository.Get(company.SICCode);
                //principal.SICCode = sic.SICCode;
                principal.Ticker = company.Ticker;
                principal.EffectiveDate = DateTime.Now;
                principal.Modifiedby = 105; //SYSADMN
                principal.ModifiedDate = DateTime.Now;
                principal.AddressTypeId = 2;
                principal.RefAccountNumber = 0;
                principal.PrivateEquityOwned = false;
                principal.PrivateEquityOwnedListId = 0;
                principal.OpenClaim = "No";
                principal.PEInceptionDate = new DateTime(1900, 01, 01);

                account.BusinessTypeID = 1; //Commercial
                account.EffectiveDate = DateTime.Now;
                account.StatusID = 3; //inplay
                account.PriorSuretyID = 0;
                account.SortIndex = 1;
                account.ModifiedBy = 155;
                account.ModifiedDate = DateTime.Now;
                account.AgencyID = 1034; //argo surety houston.. placeholder?

                _anchorUnitOfWork.PrincipalRepository.Add(principal);
                _anchorUnitOfWork.Save();

                account.PrincipalID = principal.PrincipalID;
                _anchorUnitOfWork.AccountRepository.Add(account);
                _anchorUnitOfWork.AccountFactsetLinkRepository.Add(link);
                _anchorUnitOfWork.Save();

                link.fs_perm_sec_id = company.PermanentSecurityID;
                link.AccountNumber = account.AccountNumber.ToString();
                _anchorUnitOfWork.Save();
            //return results as IEnumerable<CompanyList>;

            return new AnchorAccount()
            {
                AccountNumber = int.Parse(account.AccountNumber.ToString()),
                PrincipalName = principal.PrincipalName,
                PrimaryUW = "",
                Agency = "",
                Region = ""
            };
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //}
        }
    }
}
