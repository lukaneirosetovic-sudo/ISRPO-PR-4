using InventoryManager.Helpers;
using System.Configuration;
using System.Data;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Проверяем связь с БД при запуске
            if (!DatabaseHelper.TestConnection())
            {
                // Если БД не доступна, можно завершить приложение или показать главное окно с предупреждением
                // Для теста просто оставим как есть, сообщение об ошибке уже вылезет в MessageBox
            }
        }
    }

}
