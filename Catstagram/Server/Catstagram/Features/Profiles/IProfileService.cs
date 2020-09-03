namespace Catstagram.Features.Profiles
{
    using System.Threading.Tasks;
    using Catstagram.Data.Models;
    using Catstagram.Infrastructure.Services;
    using Models;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId, bool allInformaction = false);

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

        Task<bool> IsPublic(string userId);
    }
}
