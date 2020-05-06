using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dto
{
   public class UsersDto
    {
        public int Count { get; set; }

        public UserDetailsDto[] Users { get; set; }
    }
}
