using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Enumerations;

namespace Logger.Models.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
