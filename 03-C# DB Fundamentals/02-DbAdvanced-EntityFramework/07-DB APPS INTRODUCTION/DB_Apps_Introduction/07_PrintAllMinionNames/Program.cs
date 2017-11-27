using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07_PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> minions = new List<string>();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();
            using (connection)
            {
                var selectMinionsQuery = "SELECT * FROM Minions";
                var command = new SqlCommand(selectMinionsQuery, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    minions.Add(reader[1].ToString());
                }
            }

            int minionsLength = minions.Count;
            for (int i = 0; i < minionsLength / 2; i++)
            {
                Console.WriteLine(minions[0 + i]);
                Console.WriteLine(minions[minionsLength - i - 1]);
            }

            if(minionsLength % 2 != 0)
            {
                Console.WriteLine(minions[minionsLength / 2]);
            }
        }
    }
}
