using System;
using System.Collections.Generic;
using System.Text;

namespace _08.IncreaseMinionsAge
{
    public static class Queries
    {
        public const string SelectMinionInformation = "SELECT Name, Age FROM Minions";

        public const string UpdateMinionInformation = @"UPDATE Minions
                                                           SET Name = UPPER(LEFT(Name, 1)) +
                                                                      SUBSTRING(Name, 2, LEN(Name)),
                                                               Age += 1
                                                         WHERE Id = @Id";
    }
}
