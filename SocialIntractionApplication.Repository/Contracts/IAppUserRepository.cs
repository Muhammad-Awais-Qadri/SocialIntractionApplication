using SocialIntractionApplication.Repository.Entities;
using SocialIntractionApplication.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Repository.Contracts
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> GetUsersByOrderName(string userFirstName);
    }
}
