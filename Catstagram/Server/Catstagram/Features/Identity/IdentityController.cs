namespace Catstagram.Features.Identity
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;

    using Catstagram.Data.Models;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }
       
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName

            };

            var result = await userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [Route(nameof(Login))]

        public async Task<ActionResult<LoginResponseModel>> Login (LoginRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if(user==null)
            {
                return Unauthorized();
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if(!passwordValid)
            {
                return Unauthorized();
            }

            var token = identityService.GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSettings.Secret);


            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}