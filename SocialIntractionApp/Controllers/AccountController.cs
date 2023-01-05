using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialIntractionApp.DTOs;
using SocialIntractionApp.Utilites;
using SocialIntractionApplication.Repository.Contracts;
using SocialIntractionApplication.Repository.Entities;
using SocialIntractionApplication.Service.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace SocialIntractionApp.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IAppUserService appUserService, IUnitOfWork unitOfWork)
        {
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> RegisterUser(RegisterDto dto)
        {
            if (await _appUserService.IsExistByEmail(dto.Email))
                return BadRequest(Utility.AllReadyUserExistWithSameEmail);

            using var hmac = new HMACSHA512();

            AppUser appUser = new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };
            _appUserService.Add(appUser);
            await _unitOfWork.AsyncComplete();

            return appUser;
        }

    }
}
