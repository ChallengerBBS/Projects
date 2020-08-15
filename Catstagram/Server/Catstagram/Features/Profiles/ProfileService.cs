﻿namespace Catstagram.Features.Profiles
{
    using System.Linq;
    using System.Threading.Tasks;

    using Catstagram.Data;
    using Catstagram.Data.Models;
    using Catstagram.Features.Identity.Models;
    using Catstagram.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;

    public class ProfileService : IProfileService
    {
        private readonly CatstagramDbContext data;

        public ProfileService(CatstagramDbContext data)
        => this.data = data;

        public async Task<ProfileServiceModel> ByUser(string userId)
        => await this.data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => new ProfileServiceModel
            {
                Name = u.Profile.Name,
                MainPhotoUrl = u.Profile.MainPhotoUrl,
                Website = u.Profile.Website,
                Biography = u.Profile.Biography,
                Gender = u.Profile.Gender.ToString(),
                IsPrivate = u.Profile.IsPrivate

            })
            .FirstOrDefaultAsync();

        public async Task<Result> Update(
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
            var user = await this.data
                .Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(p => p.Id == userId);

            if (user == null)
            {
                return "User does not exist";
            }

            if (user.Profile==null)
            {
                user.Profile = new Profile();
            }


            var result = await this.ChangeProfileEmail(user, userId, email);
            if (result.Failed)
            {
                return result;
            }

            result = await this.ChangeUserName(user, userId, userName);
            if (result.Failed)
            {
                return result;
            }


            return await this.ChangeProfile(
                user.Profile,
                userId,
                email,
                userName,
                name,
                mainPhotoUrl,
                website,
                biography,
                gender,
                isPrivate);

        }

        private async Task<Result> ChangeProfileEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists)
                {
                    return "The email is already taken.";
                }

                user.Email = email;
            }
            return true;
        }

        private async Task<Result> ChangeUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists)
                {
                    return "Username is already taken";
                }

                user.UserName = userName;
            }

            return true;
        }
        private async Task<Result> ChangeProfile(
            Profile profile,
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
            if (profile.Name != name)
            {
                profile.Name = name;
            }

            if (profile.MainPhotoUrl != mainPhotoUrl)
            {
                profile.MainPhotoUrl = mainPhotoUrl;
            }

            if (profile.Website != website)
            {
                profile.Website = website;
            }

            if (profile.Biography != biography)
            {
                profile.Biography = biography;
            }

            if (profile.Gender != gender)
            {
                profile.Gender = gender;
            }

            if (profile.IsPrivate != isPrivate)
            {
                profile.IsPrivate = isPrivate;
            }
            await this.data.SaveChangesAsync();
            return true;
        }
       
    }
}
