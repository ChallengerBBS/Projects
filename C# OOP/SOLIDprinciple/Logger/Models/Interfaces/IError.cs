using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Enumerations;

namespace Logger.Models.Interfaces
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
