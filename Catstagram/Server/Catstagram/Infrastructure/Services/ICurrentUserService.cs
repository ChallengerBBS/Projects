namespace Catstagram.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetUserId();
    }
}
