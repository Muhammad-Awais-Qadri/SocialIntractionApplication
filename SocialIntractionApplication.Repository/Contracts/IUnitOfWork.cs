using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository UserRepository { get; }
        Task<int> AsyncComplete();
    }
}
