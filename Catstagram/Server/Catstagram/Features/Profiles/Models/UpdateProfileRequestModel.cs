﻿namespace Catstagram.Features.Profiles.Models
{
    using Catstagram.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Catstagram.Data.Validation.User;

    public class UpdateProfileRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string MainPhotoUrl { get; set; }

        public string Website { get; set; }

        [MaxLength(MaxBiographyLength)]
        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
