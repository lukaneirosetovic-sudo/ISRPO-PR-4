using InventoryManager.Helpers;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManager.Pages
{
    
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            LoadProducts(); 
        }

        private void LoadProducts()
        {
            List<Product> products = new List<Product>();

           
            string query = @"
                SELECT p.Id, p.Name, p.Article, p.Price, p.CurrentStock, 
                       ISNULL(c.Name, 'Без категории') AS CategoryName
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                ORDER BY p.Name";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Article = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    Price = reader.GetDecimal(3),
                                    CurrentStock = reader.GetInt32(4),
                                    CategoryName = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
      
                dgProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Здесь будет форма добавления товара.");
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
                MessageBox.Show($"Редактирование товара: {selectedProduct.Name}");
            else
                MessageBox.Show("Выберите товар для редактирования.");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show($"Удалить товар '{selectedProduct.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    MessageBox.Show("Здесь будет логика удаления.");
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }
    }
}
