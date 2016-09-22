using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BDSA2016.Lecture04.Lib
{
    public class AdoNetCharacterRepository : ICharacterRepository
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public AdoNetCharacterRepository(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public int Create(Character character)
        {
            using (var command = _connection.CreateCommand())
            {
                var query = @"INSERT Characters (GivenName, Surname, Species, Origin, Age) 
                    VALUES (@GivenName, @Surname, @Species, @Origin, @Age); 
                    SELECT SCOPE_IDENTITY()";

                command.CommandText = query;
                command.Parameters.AddWithValue("@GivenName", character.GivenName);
                command.Parameters.AddWithValue("@Surname", character.Surname);
                command.Parameters.AddWithValue("@Species", character.Species as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@Origin", character.Origin as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@Age", character.Age as object ?? DBNull.Value);

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                var id = Convert.ToInt32(command.ExecuteScalar());

                character.Id = id;

                return id;
            }        
        }

         public Character Find(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                var query = "SELECT Id, GivenName, Surname, Species, Origin, Age FROM Characters WHERE Id = @Id";

                command.CommandText = query;
                command.Parameters.AddWithValue("@Id", id);

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Character
                        {
                            Id = (int) reader["Id"],
                            GivenName = reader["GivenName"] as string,
                            Surname = reader["Surname"] as string,
                            Species = reader["Species"] as string,
                            Origin = reader["Origin"] as string,
                            Age = reader["Age"] as int?
                        };
                    }
                }

                return null;
            }
        }

        public IEnumerable<Character> Read()
        {
            using (var command = _connection.CreateCommand())
            {
                var query = "SELECT Id, GivenName, Surname, Species, Origin, Age FROM Characters";

                command.CommandText = query;

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Character
                        {
                            Id = (int) reader["Id"],
                            GivenName = reader["GivenName"] as string,
                            Surname = reader["Surname"] as string,
                            Species = reader["Species"] as string,
                            Origin = reader["Origin"] as string,
                            Age = reader["Age"] as int?
                        };
                    }
                }
            }
        }

        public bool Update(Character character)
        {
            using (var command = _connection.CreateCommand())
            {
                var query = @"UPDATE Characters SET 
                    GivenName = @GivenName, 
                    Surname = @Surname,
                    Species = @Species,
                    Origin = @Origin,
                    Age = @Age,
                    WHERE Id = @Id";

                command.CommandText = query;

                command.Parameters.AddWithValue("@Id", character.Id);
                command.Parameters.AddWithValue("@GivenName", character.GivenName);
                command.Parameters.AddWithValue("@Surname", character.Surname);
                command.Parameters.AddWithValue("@Species", character.Species as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@Origin", character.Origin as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@Age", character.Age as object ?? DBNull.Value);

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                return command.ExecuteNonQuery() > 0;
            }
        }

        public void Delete(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                var query = "DELETE Characters WHERE Id = @Id";

                command.CommandText = query;
                command.Parameters.AddWithValue("@Id", id);

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}