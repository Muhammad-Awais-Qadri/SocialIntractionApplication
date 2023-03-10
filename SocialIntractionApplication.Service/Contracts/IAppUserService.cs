using SocialIntractionApplication.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Service.Contracts
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<IEnumerable<AppUser>> FindUsersByName(string userFirstName);
        Task<AppUser?> FindUsersByEmail(string userEmail);
        Task<bool> IsExistByEmail(string userEmail);
    }
}
