namespace Catstagram.Features.Identity.Models
{
    using Catstagram.Data.Models;

    public class ProfileServiceModel
    {
        public string Name { get; set; }

        public string MainPhotoUrl { get; set; }

        public string Website { get; set; }
        public string Biography { get; set; }

        public string Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
