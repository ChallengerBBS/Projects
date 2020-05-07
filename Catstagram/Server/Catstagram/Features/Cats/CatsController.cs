namespace Catstagram.Features.Cats
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Catstagram.Infrastructure;

    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

        [Authorize]
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
    }
}