using InventoryManager.Pages;
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

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // При запуске сразу открываем страницу товаров
            MainFrame.Navigate(new ProductListPage());
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductListPage());
        }

        private void BtnMovements_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Страница движения товаров будет добавлена на следующих этапах.");
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Страница отчетов будет добавлена на следующих этапах.");
        }
    }
}