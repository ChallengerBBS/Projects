namespace Catstagram.Features.Profiles
{
    using System.Linq;
    using System.Threading.Tasks;

    using Catstagram.Data;
    using Catstagram.Data.Models;
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

        public async Task<bool> Update(
            string userId, 
            string email, 
            string userName, 
            string name, 
            string mainPhotoUrl, 
            string website, 
            string biography, 
            Gender gender, 
            bool isPrivate)

        {
            var user = await this.data.Users.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(email) && user.Email!=email)
            {
                var emailExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id!=userId&& u.Email == email);

                if(emailExists)
                {
                    return false;
                }

                user.Email = email;
            }

            if (!string.IsNullOrWhiteSpace(userName)&& user.UserName!=userName)
            {
                var userNameExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists)
                {
                    return false;
                }

                user.UserName = userName;
            }

            user.Profile.Name = name;
            user.Profile.MainPhotoUrl = mainPhotoUrl;
            user.Profile.Website = website;
            user.Profile.Biography = biography;
            user.Profile.Gender = gender;
            user.Profile.IsPrivate = isPrivate;

            await this.data.SaveChangesAsync();
            return true;
        }
    }
}
