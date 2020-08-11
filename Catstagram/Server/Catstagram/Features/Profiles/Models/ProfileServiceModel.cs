namespace Catstagram.Features.Identity.Profiles.Models
{
    using Catstagram.Data.Models;

    public class ProfileServiceModel
    {
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string Website { get; set; }
        public string Biography { get; set; }

        public string Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
