using System.Linq;
using System.Windows.Controls;
using ShiftTracker.Services;

namespace ShiftTracker.Views
{
    public partial class StatsPage : Page
    {
        private DataService _dataService;

        public StatsPage()
        {
            InitializeComponent();
            _dataService = new DataService();
            CalculateStatistics();
        }

        private void CalculateStatistics()
        {
            var shiftsList = _dataService.LoadData();

            if (shiftsList.Count > 0)
            {
                // Загальна статистика
                decimal totalEarned = shiftsList.Sum(s => s.TotalEarned);
                double totalHours = shiftsList.Sum(s => s.HoursWorked);
                double averageHours = shiftsList.Average(s => s.HoursWorked);

                txtTotalEarned.Text = $"{totalEarned:F2}";
                txtTotalHours.Text = $"{totalHours:F1}";
                txtAverageShift.Text = $"{averageHours:F1}";

                // НОВЕ: Прогрес фінансової цілі (наприклад, 10 000)
                decimal goal = 10000m;
                pbGoal.Value = (double)totalEarned;

                decimal percent = (totalEarned / goal) * 100;
                if (percent > 100) percent = 100; // Щоб не було більше 100%

                txtGoalProgress.Text = $"{totalEarned:F0} / {goal:F0} ({percent:F1}%)";

                // НОВЕ: Пошук рекордів за допомогою LINQ
                var bestShift = shiftsList.OrderByDescending(s => s.TotalEarned).First();
                var longestShift = shiftsList.OrderByDescending(s => s.HoursWorked).First();

                txtBestShift.Text = $"{bestShift.Date:dd.MM.yyyy} — {bestShift.TotalEarned:F2} грн";
                txtLongestShift.Text = $"{longestShift.Date:dd.MM.yyyy} — {longestShift.HoursWorked:F1} год";
            }
        }
    }
}