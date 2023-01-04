using SocialIntractionApplication.Repository.Contracts;
using SocialIntractionApplication.Repository.Entities;
using SocialIntractionApplication.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Service.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AppUser>> GetAll() => 
            await _unitOfWork.UserRepository.GetAll();

        public async Task<AppUser> GetById(Guid id) => 
            await _unitOfWork.UserRepository.GetById(id);

        public async Task<IEnumerable<AppUser>> GetUsersByOrderName(string userFirstName) => 
            await _unitOfWork.UserRepository.GetUsersByOrderName(userFirstName);

        public async Task<IEnumerable<AppUser>> FindAll(Expression<Func<AppUser, bool>> predicate) =>
            await _unitOfWork.UserRepository.FindAll(predicate);

        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<AppUser> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<AppUser> entities)
        {
            throw new NotImplementedException();
        }
    }
}
