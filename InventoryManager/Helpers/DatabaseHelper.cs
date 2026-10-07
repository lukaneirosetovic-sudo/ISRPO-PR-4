using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace InventoryManager.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=InventoryManager;Integrated Security=True;";

       
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}",
                                "Ошибка БД", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
