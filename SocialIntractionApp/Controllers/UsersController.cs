using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialIntractionApp.DTOs.AppUserInfo;
using SocialIntractionApplication.Repository.Entities;
using SocialIntractionApplication.Service.Contracts;

namespace SocialIntractionApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ApiBaseController
    {
        private readonly IAppUserService _appUserService;
        public UsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUserInfo>> GetAllUsers()
        {
            IEnumerable<AppUser> appUsers = await _appUserService.GetAll();

            List<AppUserInfo> users = new List<AppUserInfo>();
            if (appUsers != null && appUsers.Count() > 0)
            {
                foreach (var item in appUsers)
                {
                    users.Add(new AppUserInfo()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email
                    });
                }
            }

            return users;
        }

        [HttpGet("{id}")]
        public async Task<AppUserInfo> GetUserById(Guid id)
        {
            AppUser appUser = await _appUserService.GetById(id);

            AppUserInfo user = new AppUserInfo();
            if (appUser != null)
            {
                user.Id = appUser.Id;
                user.FirstName = appUser.FirstName;
                user.LastName = appUser.LastName;
                user.Email = appUser.Email;
            }

            return user;
        }
    }
}
