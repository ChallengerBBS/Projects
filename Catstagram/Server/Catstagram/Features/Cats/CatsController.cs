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

    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;

        }

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.catService.ByUser(userId);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id) 

            =>  await this.catService.Details(id);

        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var catId = await this.catService.Create(
                                                    model.ImageUrl, 
                                                    model.Description, 
                                                    userId);

            return Created(nameof(this.Create), catId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var updated = await this.catService.Update(model.Id, model.Description, userId);

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

        }

    }
}