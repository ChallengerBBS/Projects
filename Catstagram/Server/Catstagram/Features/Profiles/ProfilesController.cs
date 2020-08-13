namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Catstagram.Features.Identity.Models;
    using Catstagram.Infrastructure.Services;
    using Catstagram.Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore.Update.Internal;
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
        [Authorize]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
        => await this.profiles.ByUser(this.currentUser.GetId());

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.MainPhotoUrl,
                model.Website,
                model.Biography,
                model.Gender,
                model.IsPrivate
                );

            if (!updated)
            {
                return BadRequest();
            }

            return this.Ok();
        }
    }
}
