using SocialIntractionApplication.Repository.Contracts;
using SocialIntractionApplication.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Repository.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new AppUserRepository(_dbContext);
        }

        public IAppUserRepository UserRepository { get; private set; }
        public async Task<int> AsyncComplete() => await _dbContext.SaveChangesAsync();
        public void Dispose() => _dbContext.Dispose();
    }
}
