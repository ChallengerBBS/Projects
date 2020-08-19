namespace Catstagram.Features.Follows
{
    using System.Linq;
    using System.Threading.Tasks;

    using Catstagram.Data;
    using Catstagram.Data.Models;
    using Catstagram.Infrastructure.Services;
    using Microsoft.CodeAnalysis.Operations;
    using Microsoft.EntityFrameworkCore;

    public class FollowService : IFollowService
    {
        private readonly CatstagramDbContext data;

        public FollowService(CatstagramDbContext data) => this.data = data;


        public async Task<Result> Follow(string userId, string followerId)
        {
            var userAlreadyFollowed = await this.data
                .Follows
                .AnyAsync(f => f.UserId == userId && f.FollowerId == followerId);

            if (userAlreadyFollowed)
            {
                return "This user is already followed.";
            }

            var publicProfile = this.data
                .Profiles
                .Where(p => p.UserId == userId)
                .Select(p => !p.IsPrivate)
                .FirstOrDefault();

            this.data.Follows.Add(new Follow
            {
                UserId=userId,
                FollowerId=followerId,
                IsApproved= publicProfile
            });

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
