﻿namespace Catstagram.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Catstagram.Data.Models.Base;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();

    }
}
