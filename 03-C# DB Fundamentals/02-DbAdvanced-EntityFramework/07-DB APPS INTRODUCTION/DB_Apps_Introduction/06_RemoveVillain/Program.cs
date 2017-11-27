using System;
using System.Data.SqlClient;

namespace _06_RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDb;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            connection.Open();
            using (connection)
            {
                string selectVillainQuery = "SELECT [Name] FROM Villains WHERE Id = @villainId";
                var command = new SqlCommand(selectVillainQuery, connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                var villainName = command.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string releaseMinions = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                command = new SqlCommand(releaseMinions, connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                int releasedMinionsCount = command.ExecuteNonQuery();

                string deleteVillain = "DELETE FROM Villains WHERE Id = @villainId";
                command = new SqlCommand(deleteVillain, connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
                
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinionsCount} minions were released.");
            }
        }
    }
}
