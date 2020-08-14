namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;
    using Catstagram.Data.Models;
    using Catstagram.Features.Identity.Models;
    using Catstagram.Infrastructure.Services;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);

        Task<Result> Update(
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
