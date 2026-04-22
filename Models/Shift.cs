using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShiftTracker.Models
{
    public class Shift : INotifyPropertyChanged
    {
        private DateTime _date;
        private double _hoursWorked;
        private decimal _totalEarned;
        private string _notes;

        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public double HoursWorked
        {
            get => _hoursWorked;
            set { _hoursWorked = value; OnPropertyChanged(); }
        }

        public decimal TotalEarned
        {
            get => _totalEarned;
            set { _totalEarned = value; OnPropertyChanged(); }
        }

        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}