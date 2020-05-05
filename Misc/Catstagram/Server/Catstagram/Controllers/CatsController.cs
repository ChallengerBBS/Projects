namespace Catstagram.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Catstagram.Models.Cats;
    
    public class CatsController : ApiController
    {
        [Authorize]
        [HttpPost]

        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        { 

        }
    }
}