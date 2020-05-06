using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Interfaces;

namespace Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";

    }
}
