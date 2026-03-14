using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace EvsonHardware.Data
{
    public static class Database
    {
        private const string DatabaseFileName = "evson_hardware.sqlite";

        public static SqliteConnection GetConnection()
        {
            string dbPath = ResolveDatabasePath();
            return new SqliteConnection($"Data Source={dbPath}");
        }

        private static string ResolveDatabasePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string? current = baseDir;
            var probed = new List<string>();
            string? fallback = null;

            for (int i = 0; i < 8 && !string.IsNullOrWhiteSpace(current); i++)
            {
                string inData = Path.GetFullPath(Path.Combine(current, "Data", DatabaseFileName));
                probed.Add(inData);
                if (File.Exists(inData)) return inData;

                string direct = Path.GetFullPath(Path.Combine(current, DatabaseFileName));
                probed.Add(direct);
                if (File.Exists(direct))
                {
                    var info = new FileInfo(direct);
                    if (info.Length > 0) return direct;
                    fallback ??= direct;
                }

                var parent = Directory.GetParent(current);
                if (parent == null) break;
                current = parent.FullName;
            }

            if (!string.IsNullOrWhiteSpace(fallback)) return fallback;

            throw new FileNotFoundException(
                $"Unable to locate '{DatabaseFileName}'. Checked: {string.Join("; ", probed)}");
        }
    }
}
