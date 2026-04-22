using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ShiftTracker.Models;

namespace ShiftTracker.Services
{
    public class DataService
    {
        private readonly string filePath = "shifts.json";

        public List<Shift> LoadData()
        {
            if (!File.Exists(filePath))
                return new List<Shift>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Shift>>(json) ?? new List<Shift>();
        }

        public void SaveData(List<Shift> shifts)
        {
            string json = JsonSerializer.Serialize(shifts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}