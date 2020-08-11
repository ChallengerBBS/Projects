namespace Catstagram.Features.Profiles
{
    using System.Linq;
    using System.Threading.Tasks;

    using Catstagram.Data;
    using Catstagram.Features.Identity.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProfileService : IProfileService
    {
        private readonly CatstagramDbContext data;

        public ProfileService(CatstagramDbContext data)
        =>  this.data = data;

        public async Task<ProfileServiceModel> ByUser(string userId)
        => await this.data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => new ProfileServiceModel
            {
                Name = u.Profile.Name,
                MainPhotoUrl=u.Profile.MainPhotoUrl,
                Website= u.Profile.Website,
                Biography = u.Profile.Biography,
                Gender = u.Profile.Gender.ToString(),
                IsPrivate=u.Profile.IsPrivate

            })
            .FirstOrDefaultAsync();
    }
}
