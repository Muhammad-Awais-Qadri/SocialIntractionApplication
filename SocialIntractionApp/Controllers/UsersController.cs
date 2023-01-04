using Microsoft.AspNetCore.Mvc;
using SocialIntractionApplication.Repository.Entities;
using SocialIntractionApplication.Service.Contracts;

namespace SocialIntractionApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiBaseController
    {
        private readonly IAppUserService _appUserService;
        public UsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _appUserService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<AppUser> GetUserById(Guid id)
        {
            return await _appUserService.GetById(id);
        }
    }
}
