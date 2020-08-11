namespace Catstagram.Features.Cats
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Features.Cats.Models;
    using Features.Cat.Models;
    using Infrastructure.Extensions;

    using static Infrastructure.WebConstants;
    using Catstagram.Infrastructure.Services;

    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService cats;
        private readonly ICurrentUserService currentUser;

        public CatsController(ICatService cats, ICurrentUserService currentUser)
        {
            this.cats = cats;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        => await this.cats.ByUser(this.currentUser.GetId());


        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)

            => await this.cats.Details(id);

        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var catId = await this.cats.Create(
                                                    model.ImageUrl,
                                                    model.Description,
                                                    userId);

            return Created(nameof(this.Create), catId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.cats.Update(model.Id, model.Description, userId);

            if (!updated)
            {
                return BadRequest();
            }

            return this.Ok();


        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var deleted = await this.cats.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }
            return Ok();

        }

    }
}