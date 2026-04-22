using System.Windows;
using System.Windows.Controls;

namespace ShiftTracker.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            App.ToggleTheme();
        }

        private void LangUa_Click(object sender, RoutedEventArgs e)
        {
            App.SetLanguage("UA");
        }

        private void LangEn_Click(object sender, RoutedEventArgs e)
        {
            App.SetLanguage("EN");
        }
    }
}