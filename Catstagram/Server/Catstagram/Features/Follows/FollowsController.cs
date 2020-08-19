namespace Catstagram.Features.Follows
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Catstagram.Features.Follows.Models;
    using Catstagram.Infrastructure.Services;

    public class FollowsController : ApiController
    {
        private readonly IFollowService follows;
        private readonly ICurrentUserService currentUser;

        public FollowsController(IFollowService follows, ICurrentUserService currentUser)
        {
            this.follows = follows;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var result = await this.follows.Follow(
                model.UserId,
                this.currentUser.GetId());

            if (result.Failed)
            {
                return BadRequest(result.Error);
            }


            return this.Ok();
        }
    }
}
