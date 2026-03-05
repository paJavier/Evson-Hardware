using Microsoft.Data.Sqlite;
using System;

namespace EvsonHardware.Data
{
    public class Database
    {
        private static string connectionString =
            @"Data Source=Data\evson_hardware.sqlite;Cache=Shared;Mode=ReadWriteCreate;";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }
}
