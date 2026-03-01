using Microsoft.Data.Sqlite;
using System;

namespace EvsonHardware.Data
{
    public class Database
    {
        private static string connectionString = "Data Source=EvsonHardware.db";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }

        public static void Initialize()
        {
            using var conn = GetConnection();
            conn.Open();

            var pragmaCmd = conn.CreateCommand();
            pragmaCmd.CommandText = "PRAGMA foreign_keys = ON;";
            pragmaCmd.ExecuteNonQuery();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                -- 1. Users Table (Core for Auth)
                CREATE TABLE IF NOT EXISTS User (
                    user_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL UNIQUE,
                    password_hash TEXT NOT NULL,
                    role TEXT NOT NULL,
                    is_active INTEGER NOT NULL DEFAULT 1
                );

                -- 2. Product Table (Updated with Category and Reorder Point)
                CREATE TABLE IF NOT EXISTS Product (
                    product_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    product_name TEXT NOT NULL,
                    category TEXT,
                    price REAL NOT NULL,
                    stock INTEGER NOT NULL DEFAULT 0,
                    reorder_level INTEGER DEFAULT 10,
                    is_active INTEGER NOT NULL DEFAULT 1
                );

                -- 3. Supply Records (Procurement)
                CREATE TABLE IF NOT EXISTS Supply (
                    supply_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    supply_date TEXT NOT NULL,
                    supplier_name TEXT,
                    total_amount REAL,
                    user_id INTEGER NOT NULL,
                    FOREIGN KEY (user_id) REFERENCES User(user_id)
                );

                -- 4. Supply Details (Items received)
                CREATE TABLE IF NOT EXISTS Supply_Details (
                    supply_id INTEGER NOT NULL,
                    product_id INTEGER NOT NULL,
                    quantity INTEGER NOT NULL,
                    unit_cost REAL NOT NULL,
                    PRIMARY KEY (supply_id, product_id),
                    FOREIGN KEY (supply_id) REFERENCES Supply(supply_id),
                    FOREIGN KEY (product_id) REFERENCES Product(product_id)
                );

                -- 5. Sales Records (Transactions)
                CREATE TABLE IF NOT EXISTS Sale (
                    sale_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    receipt_number TEXT UNIQUE NOT NULL,
                    sale_date TEXT NOT NULL,
                    customer_name TEXT,
                    total_amount REAL,
                    user_id INTEGER NOT NULL,
                    FOREIGN KEY (user_id) REFERENCES User(user_id)
                );

                -- 6. Sales Details (Specific Items Sold)
                CREATE TABLE IF NOT EXISTS Sales_Details (
                    sales_detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    sale_id INTEGER NOT NULL,
                    product_id INTEGER NOT NULL,
                    quantity INTEGER NOT NULL,
                    unit_price REAL NOT NULL,
                    FOREIGN KEY (sale_id) REFERENCES Sale(sale_id),
                    FOREIGN KEY (product_id) REFERENCES Product(product_id)
                );

                -- 7. Returns (Customer Returns)
                CREATE TABLE IF NOT EXISTS Return_Transaction (
                    return_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    sale_id INTEGER,
                    return_date TEXT NOT NULL,
                    reason TEXT,
                    user_id INTEGER NOT NULL,
                    FOREIGN KEY (sale_id) REFERENCES Sale(sale_id),
                    FOREIGN KEY (user_id) REFERENCES User(user_id)
                );
            ";

            cmd.ExecuteNonQuery();
        }
    }
}