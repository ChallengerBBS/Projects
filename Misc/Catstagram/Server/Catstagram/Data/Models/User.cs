namespace Catstagram.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();
    }
}
