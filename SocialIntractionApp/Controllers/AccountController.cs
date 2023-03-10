using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialIntractionApp.DTOs.Authentication;
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
        private readonly ITokenService _tokenService;

        public AccountController(
            IAppUserService appUserService,
            IUnitOfWork unitOfWork,
            ITokenService tokenService
            )
        {
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserTokenDto>> RegisterUser(RegisterDto dto)
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

            return new UserTokenDto { UserEmail = appUser.Email, Token = _tokenService.CreateToken(appUser) };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDto>> LoginUser(LoginDto dto)
        {
            AppUser? appUser = await _appUserService.FindUsersByEmail(dto.Email);
            if (appUser == null) return Unauthorized(Utility.UserInvalid);

            using var hmac = new HMACSHA512(appUser.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != appUser.PasswordHash[i]) return Unauthorized(Utility.PasswordInvalid);
            }

            return new UserTokenDto { UserEmail = appUser.Email, Token = _tokenService.CreateToken(appUser) };
        }

    }
}
