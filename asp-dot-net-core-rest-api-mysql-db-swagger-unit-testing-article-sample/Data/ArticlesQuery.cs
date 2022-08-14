using ArticleSampleAPI.Data;
using ArticleSampleAPI.Models;
using MySqlConnector;
using System.Data.Common;
using System.Data;

namespace ArticleSampleAPI.Data
{
    public class ArticlesQuery
    {
        public AppDb Db { get; }

        public ArticlesQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Articles> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `name`, `authors` FROM `Articles` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Articles>> GetAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `name`, `authors` FROM `Articles` ORDER BY `id` ;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Articles>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Articles>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Articles(Db)
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Authors = reader.GetString(2),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }

    }
}