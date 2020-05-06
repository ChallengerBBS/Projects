using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NullOrEmptyNameException = "Name cannot be empty";

        public static string MoneyNegativeException = "Money cannot be negative";
        public static string CannotAffordAProductException = "{0} can't afford {1}";
    }
}
