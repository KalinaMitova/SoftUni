using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08_IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDb;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            connection.Open();
            using (connection)
            {
                string updateMinionsQuery = $"UPDATE Minions SET[Name] = UPPER(LEFT([Name], 1)) + RIGHT([Name], LEN([Name]) - 1), Age += 1 WHERE Id IN({string.Join(", ", ids)})";

                var command = new SqlCommand(updateMinionsQuery, connection);
                foreach (var id in ids)
                {
                    command.Parameters.AddWithValue(id.ToString(), id);
                }

                command.ExecuteNonQuery();

                string selectMinionsQuery = "SELECT * FROM Minions";
                command = new SqlCommand(selectMinionsQuery, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[1]} {reader[2]}");
                }
            }          
        }
    }
}
