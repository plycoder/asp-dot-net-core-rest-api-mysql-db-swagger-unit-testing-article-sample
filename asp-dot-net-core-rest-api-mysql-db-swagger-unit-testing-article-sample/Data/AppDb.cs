using System;
using ArticleSampleAPI.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace ArticleSampleAPI.Data
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection { get; }

        public AppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public DbSet<Articles> Article { get; set; }

        public void Dispose() => Connection.Dispose();
    }
}