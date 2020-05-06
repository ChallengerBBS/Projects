using System;

namespace Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string EXC_MESSAGE = "Invalid level type !";
        public InvalidLevelTypeException()
        :base(EXC_MESSAGE)
        {
            
        }

        public InvalidLevelTypeException(string message)
        : base(message)
        {
            
        }
    }
}
