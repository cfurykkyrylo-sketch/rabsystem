using System;
using System.Linq;
using System.Windows;

namespace ShiftTracker
{
    public partial class App : Application
    {
        public static bool IsDarkTheme { get; private set; } = true;

        public static void ToggleTheme()
        {
            IsDarkTheme = !IsDarkTheme;
            UpdateResource("Themes", IsDarkTheme ? "DarkTheme.xaml" : "LightTheme.xaml");
        }

        public static void SetLanguage(string langCode)
        {
            UpdateResource("Languages", $"Lang{langCode}.xaml");
        }

        private static void UpdateResource(string folder, string fileName)
        {
            var resourceUri = new Uri($"Resources/{folder}/{fileName}", UriKind.Relative);
            var newResource = new ResourceDictionary { Source = resourceUri };

            // Знаходимо старий словник (теми або мови) і видаляємо його
            var oldResource = Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains(folder));

            if (oldResource != null)
                Current.Resources.MergedDictionaries.Remove(oldResource);

            // Додаємо новий
            Current.Resources.MergedDictionaries.Add(newResource);
        }
    }
}