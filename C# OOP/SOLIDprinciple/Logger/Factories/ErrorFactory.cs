using System;
using System.Globalization;

using Logger.Exceptions;
using Logger.Models.Errors;
using Logger.Models.Interfaces;
using Logger.Models.Enumerations;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        public IError GetError(string dateString, string levelString, string message)
        {

            Level level;

            bool isParsed = Enum.TryParse<Level>(levelString, out level);

            if (!isParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime; 
            try
            {
                dateTime= DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
