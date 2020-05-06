using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _04.AddMinion
{
    class Program
    {
        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;" +
                                                  "Database=MinionsDB;" +
                                                  "Integrated Security=True;";

        private static SqlConnection connection = new SqlConnection(connectionString);
        public static int _TownId;
        public static int _MinionId;
        public static int _VillainId;

        static void Main(string[] args)
        {


            List<string> minionsItems = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

            string minionName = minionsItems[0];
            int minionAge = int.Parse(minionsItems[1]);
            string minionTown = minionsItems[2];

            List<string> villainsItems = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

            string villainName = villainsItems[0];

            using (connection)
            {
                connection.Open();

                ExecuteTownQuery(minionTown, connection);
                ExecuteMinionQuery(minionName, minionAge, connection);
                ExecuteVilainQuery(villainName, connection);
                ExecuteAddMinionToVillainQuery(minionName, villainName, connection);
            }
        }

        private static void ExecuteTownQuery(string minionTown, SqlConnection connection)
        {
            using (SqlCommand checkTownCommand = new SqlCommand(Queries.TakeTownId, connection))
            {
                checkTownCommand.Parameters.AddWithValue("@townName", minionTown);
                

                object targetId = checkTownCommand.ExecuteScalar();

                if (targetId != null)
                {
                    _TownId = (int)targetId;
                }
                else
                {
                    using (SqlCommand insertTownCommand = new SqlCommand(Queries.InsertTown, connection))
                    {
                        insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
                        insertTownCommand.ExecuteNonQuery();

                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteMinionQuery(string minionName, int minionAge, SqlConnection connection)
        {
            using (SqlCommand checkMinionCommand = new SqlCommand(Queries.TakeMinionId, connection))
            {
                checkMinionCommand.Parameters.AddWithValue("@Name", minionName);

                object targetId = checkMinionCommand.ExecuteScalar();

                if (targetId != null)
                {
                    _MinionId = (int)targetId;
                }
                else
                {
                    using (SqlCommand insertMinionCommand = new SqlCommand(Queries.InsertMinion, connection))
                    {
                        insertMinionCommand.Parameters.AddWithValue("@nam", minionName);
                        insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                        insertMinionCommand.Parameters.AddWithValue("@townId", _TownId);

                        insertMinionCommand.ExecuteNonQuery();

                        Console.WriteLine($"Minion {minionName} was added to the database.");
                    }
                }
            }
        }

       

        private static void ExecuteVilainQuery(string villainName, SqlConnection connection)
        {
            using (SqlCommand checkVillainCommand = new SqlCommand(Queries.TakeVillainId, connection))
            {
                checkVillainCommand.Parameters.AddWithValue("@Name", villainName);

                object targetId = checkVillainCommand.ExecuteScalar();

                if (targetId != null)
                {
                    _VillainId = (int)targetId;
                }
                else
                {
                    using (SqlCommand insertVillainCommand = new SqlCommand(Queries.InsertVillain, connection))
                    {
                        insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                        insertVillainCommand.ExecuteNonQuery();

                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteAddMinionToVillainQuery(string minionName, string villainName, SqlConnection connection)
        {
            using (SqlCommand insertMinionToVilainCommand = new SqlCommand(Queries.InsertMV, connection))
            {
                insertMinionToVilainCommand.Parameters.AddWithValue("@villainId", _VillainId);
                insertMinionToVilainCommand.Parameters.AddWithValue("@minionId", _MinionId);
                insertMinionToVilainCommand.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }




    }
}


    

