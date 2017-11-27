using System;
using System.Data.SqlClient;

namespace _04_AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            var minionInput = Console.ReadLine().Split();
            var minionName = minionInput[1];
            var minionAge = int.Parse(minionInput[2]);
            var minionTown = minionInput[3];
            var minionCountry = minionInput[4];

            var villainName = Console.ReadLine().Split()[1];

            var connectionString = new SqlConnectionStringBuilder()
            {
                ["Server"] = @"(localdb)\MSSQLLocalDB",
                ["Database"] = "MinionsDB",
                ["Integrated Security"] = "True"
            };

            var connection = new SqlConnection(connectionString.ToString());

            connection.Open();
            using (connection)
            {
                //Country check and add to DB if not exist
                var checkCountry = "SELECT * FROM Countries WHERE [Name] = @countryName";

                var countryCommand = new SqlCommand(checkCountry, connection);
                countryCommand.Parameters.AddWithValue("@countryName", minionCountry);

                var countryId = countryCommand.ExecuteScalar();

                if (countryId == null)
                {
                    var insertCountry = "INSERT INTO Countries ([Name]) VALUES (@countryName); SELECT SCOPE_IDENTITY();";
                    countryCommand.CommandText = insertCountry;
                    countryId = countryCommand.ExecuteScalar();
                    Console.WriteLine($"Country {minionCountry} is inserted to Database with Id {countryId}!");
                }
                else
                {
                    Console.WriteLine($"There is already have a country with Id {countryId}!");
                }

                //Town check and add to DB if not exist
                var checkTown = "SELECT * FROM Towns WHERE [Name] = @townName";

                var townCommand = new SqlCommand(checkTown, connection);
                townCommand.Parameters.AddWithValue("@townName", minionTown);

                var townId = townCommand.ExecuteScalar();

                if (townId == null)
                {
                    var insertCountry = "INSERT INTO Towns ([Name], [CountryId]) VALUES (@townName, @countryId); SELECT SCOPE_IDENTITY();";
                    townCommand.CommandText = insertCountry;
                    townCommand.Parameters.AddWithValue("@countryId", countryId);
                    townId = townCommand.ExecuteScalar();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }
                else
                {
                    Console.WriteLine($"There is already have a town with Id {townId}!");
                }

                //Villain check and add to DB if not exist
                var checkVillain = "SELECT * FROM Villains WHERE [Name] = @villainName";

                var villainCommand = new SqlCommand(checkVillain, connection);
                villainCommand.Parameters.AddWithValue("@villainName", villainName);

                var villainId = villainCommand.ExecuteScalar();

                if (villainId == null)
                {
                    var insertVillain = "INSERT INTO Villains([Name], EvilnessFactorId) VALUES (@villainName, 4); SELECT SCOPE_IDENTITY();";
                    villainCommand.CommandText = insertVillain;
                    villainId = villainCommand.ExecuteScalar();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }
                else
                {
                    Console.WriteLine($"There is already have a villain with Id {villainId}!");
                }

                //Minion check and add to DB if not exist
                var checkMinion = "SELECT * FROM Minions WHERE [Name] = @minionName";

                var minionCommand = new SqlCommand(checkMinion, connection);
                minionCommand.Parameters.AddWithValue("@minionName", minionName);

                var minionId = minionCommand.ExecuteScalar();

                if (minionId == null)
                {
                    var insertMinion = "INSERT INTO Minions([Name], Age, TownId) VALUES (@minionName, @minionAge, @townId); SELECT SCOPE_IDENTITY();";
                    minionCommand.CommandText = insertMinion;
                    minionCommand.Parameters.AddWithValue("@minionAge", minionAge);
                    minionCommand.Parameters.AddWithValue("@townId", townId);
                    minionId = minionCommand.ExecuteScalar();
                    Console.WriteLine($"Successfully added {minionName}.");
                }
                else
                {
                    Console.WriteLine($"There is already have a minion with Id {minionId}!");
                }

                //Villain minion check and add to DB if not exist
                var checkVillainMinion = "SELECT * FROM MinionsVillains WHERE MinionId = @minionId AND VillainId = @villainId";

                var villainMinionCommand = new SqlCommand(checkVillainMinion, connection);
                villainMinionCommand.Parameters.AddWithValue("@minionId", int.Parse(minionId.ToString()));
                villainMinionCommand.Parameters.AddWithValue("@villainId", int.Parse(villainId.ToString()));

                var isMinionVillain = villainMinionCommand.ExecuteScalar();

                if (isMinionVillain == null)
                {
                    var insertvillainMinion = "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES (@minionId, @villainId)";
                    villainMinionCommand.CommandText = insertvillainMinion;
                    villainMinionCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
                else
                {
                    Console.WriteLine($"There is already have a minion with Id {minionId} and Villain with Id {villainId} in MinionsVillains DB!");
                }

            }
        }
    }
}
