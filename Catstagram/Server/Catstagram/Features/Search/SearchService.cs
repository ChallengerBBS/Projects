namespace Catstagram.Features.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catstagram.Data;
    using Catstagram.Features.Search.Models;
    using Microsoft.EntityFrameworkCore;

    public class SearchService : ISearchService
    {
        private readonly CatstagramDbContext data;

        public SearchService(CatstagramDbContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
        => await this.data
            .Users
            .Where(u => u.UserName
                        .Contains(query.ToLower()) ||
                     u.Profile.Name
                        .Contains(query.ToLower()))
            .Select(u => new ProfileSearchServiceModel
            {
                UserId = u.Id,
                UserName = u.UserName,
                ProfilePhotoUrl = u.Profile.MainPhotoUrl
            })
            .ToListAsync();
    }
}
