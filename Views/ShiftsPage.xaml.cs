using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ShiftTracker.Models;
using ShiftTracker.Services;

namespace ShiftTracker.Views
{
    public partial class ShiftsPage : Page
    {
        private DataService _dataService;

        // ОСЬ ВОНА - вимога з методички!
        private ObservableCollection<Shift> _shifts;

        private readonly decimal hourlyRate = 77m;

        public ShiftsPage()
        {
            InitializeComponent();
            _dataService = new DataService();
            LoadShifts();
        }

        private void LoadShifts()
        {
            // Завантажуємо з файлу і загортаємо в ObservableCollection
            var loadedShifts = _dataService.LoadData();
            _shifts = new ObservableCollection<Shift>(loadedShifts);

            gridShifts.ItemsSource = _shifts;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.SelectedDate == null || string.IsNullOrWhiteSpace(txtHours.Text))
            {
                MessageBox.Show("Будь ласка, оберіть дату та введіть години.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (double.TryParse(txtHours.Text.Replace('.', ','), out double hours))
            {
                var newShift = new Shift
                {
                    Date = dpDate.SelectedDate.Value,
                    HoursWorked = hours,
                    TotalEarned = (decimal)hours * hourlyRate,
                    Notes = txtNotes.Text ?? ""
                };

                _shifts.Add(newShift);
                _dataService.SaveData(_shifts.ToList()); // Зберігаємо у файл

                txtHours.Clear();
                txtNotes.Clear();
            }
            else
            {
                MessageBox.Show("Неправильний формат годин. Використовуйте цифри.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gridShifts.SelectedItem is Shift selectedShift)
            {
                _shifts.Remove(selectedShift);
                _dataService.SaveData(_shifts.ToList());
            }
        }
    }
}