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
            // Go from bin/Debug → project root
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string dbPath = Path.GetFullPath(
                Path.Combine(baseDir, @"..\..\..\Data\evson_hardware.sqlite")
            );

            return new SqliteConnection($"Data Source={dbPath}");
        }
    }
}