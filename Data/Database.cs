using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Reflection;

namespace EvsonHardware.Data
{
    public static class Database
    {
        public static SqliteConnection GetConnection()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string dbPath = Path.Combine(baseDir, "evson_hardware.sqlite");

            return new SqliteConnection($"Data Source={dbPath}");
        }
    }
}