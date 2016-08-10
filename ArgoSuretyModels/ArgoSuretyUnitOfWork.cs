using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.ArgoSuretyModels
{

    public class ArgoSuretyUnitOfWork : IDisposable
    {
        private ArgoSuretyEntities context = new ArgoSuretyEntities();
        private GenericRepository<ArgAMS_Account> accountRepository;
        private GenericRepository<ArgAMS_Principal> principalRepository;
        private GenericRepository<ArgAMS_AccountFactsetSecurity> accountFactsetRepository;
        private GenericRepository<ArgAMS_SICode> sicRepository;
        private GenericRepository<ArgSec_User> userRepository;

        public GenericRepository<ArgAMS_Account> AccountRepository
        {
            get
            {
                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<ArgAMS_Account>(context);
                }
                return accountRepository;
            }
        }

        public GenericRepository<ArgAMS_Principal> PrincipalRepository
        {
            get
            {
                if (this.principalRepository == null)
                {
                    this.principalRepository = new GenericRepository<ArgAMS_Principal>(context);
                }
                return principalRepository;
            }
        }

        public GenericRepository<ArgAMS_AccountFactsetSecurity> AccountFactsetLinkRepository
        {
            get
            {
                if (this.accountFactsetRepository == null)
                {
                    this.accountFactsetRepository = new GenericRepository<ArgAMS_AccountFactsetSecurity>(context);
                }
                return accountFactsetRepository;
            }
        }

        public GenericRepository<ArgAMS_SICode> SICRepository
        {
            get
            {
                if (this.sicRepository == null)
                {
                    this.sicRepository = new GenericRepository<ArgAMS_SICode>(context);
                }
                return sicRepository;
            }
        }

        public GenericRepository<ArgSec_User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<ArgSec_User>(context);
                }
                return userRepository;
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