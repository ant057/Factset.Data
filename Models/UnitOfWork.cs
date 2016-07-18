using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    public class UnitOfWork : IDisposable
    {
        private FactsetEntities context = new FactsetEntities();
        private Repository<ff_basic_v2> companyRespository;
        private Repository<ff_basic_af_v2> basicAnnualRespository;
        private CompanySearchRepository companySearchRepository;

        public Repository<ff_basic_v2> CompanyRespository
        {
            get
            {
                if (this.companyRespository == null)
                {
                    this.companyRespository = new Repository<ff_basic_v2>(context);
                }
                return companyRespository;
            }
        }

        public CompanySearchRepository CompanySearchRepository
        {
            get
            {
                if (this.companySearchRepository == null)
                {
                    this.companySearchRepository = new CompanySearchRepository(context);
                }
                return companySearchRepository;
            }
        }

        //TODO: financial factory?
        public Repository<ff_basic_af_v2> FinancialRepository
        {
            get
            {
                if (this.basicAnnualRespository == null)
                {
                    this.basicAnnualRespository = new Repository<ff_basic_af_v2>(context);
                }
                return basicAnnualRespository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}