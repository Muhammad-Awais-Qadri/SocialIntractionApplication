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
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext dbContext): base(dbContext)
        {

        }
        public async Task<IEnumerable<AppUser>> GetUsersByOrderName(string userFirstName) =>
            await ApplicationDbContext.AppUsers.Where(u => u.FirstName.Contains(userFirstName)).ToListAsync();

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _dbContext as ApplicationDbContext; }
        }
    }
}
