using SocialIntractionApplication.Repository.Entities;
using SocialIntractionApplication.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Repository.Contracts
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> FindUsersByName(string userFirstName);
        Task<AppUser?> FindUsersByEmail(string userEmail);
        Task<bool> IsExistByEmail(string userEmail);
    }
}
