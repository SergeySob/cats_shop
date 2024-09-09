using Npgsql;

namespace cats_shop
{
    internal class DataBase
    {
        private static string constring = "Host=localhost;Username=postgres;Password=VEST777berto;Database=postgres";

        public async Task<cat> getCatPosition(int position)
        {
            using (var conn = new NpgsqlConnection(constring))
            {
                await conn.OpenAsync();
                string query = $"SELECT p.cost, c.age, c.gender, b.breed, col.colour FROM cats_shop.position p JOIN cats_shop.cats c ON p.cat = c.id JOIN cats_shop.breeds b ON c.breed = b.id JOIN cats_shop.colour col ON c.colour = col.id WHERE p.id = @position;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@position", position);
                    var reader = await cmd.ExecuteReaderAsync();
                    await reader.ReadAsync();
                    var cat = new cat
                    {
                        age = (int)reader["age"],
                        breed = (string)reader["breed"],
                        colour = (string)reader["colour"],
                        gender = (string)reader["gender"]
                    };

                    return cat;
                }
            }

        }

        public async Task<bool> createCat(cat cat)
        {
            using (var conn = new NpgsqlConnection(constring))
            {
                await conn.OpenAsync();
                string query = $"";

                using (var cmd = new NpgsqlCommand(query, conn))
                {

                }
            }

            return true;
        }

        public async Task<bool> removeCatPosition(int position)
        {
            using (var conn = new NpgsqlConnection(constring))
            {
                await conn.OpenAsync();
                string query = $"DELETE FROM cats_shop.position WHERE id = @position;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@position", position);
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }

            
        }
    }
}
