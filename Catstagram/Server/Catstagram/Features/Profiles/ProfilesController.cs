namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;
    using Catstagram.Features.Follows;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    using static Infrastructure.WebConstants;

    public class ProfilesController : ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;
        private readonly IFollowService follows;

        public ProfilesController(IProfileService profiles, 
                                ICurrentUserService currentUser,
                                IFollowService follows)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
            this.follows = follows;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
        => await this.profiles.ByUser(this.currentUser.GetId(), allInformaction: true);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ProfileServiceModel>> Details(string id)
        {
            var includeAllInformation = await this.follows.IsFollower(id, this.currentUser.GetId());

            if (!includeAllInformation)
            {
                includeAllInformation = !await this.profiles.IsPublic(id); 
            }

            return await this.profiles.ByUser(id, includeAllInformation);
        }

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
