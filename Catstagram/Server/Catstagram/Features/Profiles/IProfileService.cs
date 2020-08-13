namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;
    using Catstagram.Data.Models;
    using Catstagram.Features.Identity.Models;
    
    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);

        Task<bool> Update(
            string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl,
            string website,
            string biography,
            Gender gender,
            bool isPrivate);
    }
}
