namespace Catstagram.Features.Search
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Catstagram.Features.Search.Models;

    public interface ISearchService
    {
        Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query);
    }
}
