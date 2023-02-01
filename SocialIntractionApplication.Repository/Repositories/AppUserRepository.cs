using Microsoft.EntityFrameworkCore;
using SocialIntractionApplication.Repository.Contracts;
using SocialIntractionApplication.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Repository.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<AppUser>> FindUsersByName(string userFirstName) =>
            await ApplicationDbContext.AppUsers.Where(u => u.FirstName.Contains(userFirstName)).ToListAsync();

        public async Task<AppUser?> FindUsersByEmail(string userEmail) =>
            await ApplicationDbContext.AppUsers.SingleOrDefaultAsync(u => u.Email.Equals(userEmail));

        public async Task<bool> IsExistByEmail(string userEmail) =>
            await ApplicationDbContext.AppUsers.AnyAsync(u => u.Email.Equals(userEmail));

        public ApplicationDbContext ApplicationDbContext
        {
            get { return (ApplicationDbContext)_dbContext; }
        }
    }
}
