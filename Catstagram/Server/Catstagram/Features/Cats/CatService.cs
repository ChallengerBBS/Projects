﻿namespace Catstagram.Features.Cats
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Catstagram.Data;
    using Catstagram.Data.Models;
    using Catstagram.Features.Cats.Models;
    using Catstagram.Infrastructure.Services;

    public class CatService : ICatService
    {
        private readonly CatstagramDbContext data;

        public CatService(CatstagramDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.data.Add(cat);
            await this.data.SaveChangesAsync();

            return cat.Id;
        }

        public async Task<Result> Update(int id, string description, string userId)
        {
            var cat = await this.GetByUserAndById(id, userId);

            if (cat==null)
            {
                return "This user cannot edit this cat";
            }

            cat.Description = description;
            await this.data.SaveChangesAsync();
            return true;

        }

        public async Task<Result> Delete(int id, string userId)
        {
            var cat = await this.GetByUserAndById(id, userId);
            if (cat == null)
            {
                return "This user cannot delete this cat";
            }

            this.data.Remove(cat);
            await this.data.SaveChangesAsync();

            return true;

        }
        public async Task<IEnumerable<CatListingServiceModel>> ByUser(string userId)
        => await this.data
            .Cats
            .Where(c => c.UserId == userId)
            .OrderBy(c=>c.CreatedOn)
            .Select(c => new CatListingServiceModel
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl
            })
            .ToListAsync();


        public async Task<CatDetailsServiceModel> Details(int id)
        => await this.data
            .Cats
            .Where(c => c.Id == id)
            .Select(c => new CatDetailsServiceModel
            {
                Id = c.Id,
                UserId = c.UserId,
                ImageUrl = c.ImageUrl,
                Description = c.Description,
                UserName = c.User.UserName
            })
            .FirstOrDefaultAsync();

        private async Task<Cat> GetByUserAndById(int id, string userId)
        => await this.data
                .Cats
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();

    }
}
