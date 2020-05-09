﻿namespace Catstagram.Features.Cats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICatService
    {
        public Task<int> Create(string imageUrl, string description, string userId);

        public Task<IEnumerable<CatListingResponseModel>> ByUser(string userId);
    }
}
