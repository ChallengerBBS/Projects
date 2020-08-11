namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;

    using Catstagram.Features.Identity.Models;
    
    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);

    }
}
