using System.Windows;

namespace ShiftTracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // АВТОМАТИЧНИЙ ЗАПУСК ГОЛОВНОЇ СТОРІНКИ
            MainFrame.Navigate(new Views.HomePage());
        }

        // Обробник для кнопки "Приєднуйтесь до rabsystem"
        private void NavHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.HomePage());
        }

        private void NavShifts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.ShiftsPage());
        }

        private void NavStats_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.StatsPage());
        }

        private void NavSettings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.SettingsPage());
        }
    }
}