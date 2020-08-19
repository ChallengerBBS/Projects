using Catstagram.Infrastructure.Services;
using System.Threading.Tasks;

namespace Catstagram.Features.Follows
{
    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followerId);
    }
}
