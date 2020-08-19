namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Mvc;

    using Catstagram.Features.Identity.Models;
    using Catstagram.Infrastructure.Services;
    using Catstagram.Features.Profiles.Models;

    public class ProfilesController : ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;
        public ProfilesController(IProfileService profiles, ICurrentUserService currentUser)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
        => await this.profiles.ByUser(this.currentUser.GetId());

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.MainPhotoUrl,
                model.Website,
                model.Biography,
                model.Gender,
                model.IsPrivate);

            if (result.Failed)
            {
                return BadRequest(result.Error);
            }

            return this.Ok();
        }
    }
}
