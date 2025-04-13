using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using PysmennyiDateFinal.Models;
using CommunityToolkit.Mvvm.Input;
using PysmennyiDateFinal.Services;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PysmennyiDateFinal.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private readonly string _filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "data.json");

        private ObservableCollection<Person> _people = [];

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand CreatePersonCommand { get; }

        public RelayCommand SaveJsonCommand { get; }

        public MainViewModel()
        {
            LoadJson();
            CreatePersonCommand = new RelayCommand(ToPersonCreation);
            SaveJsonCommand = new RelayCommand(SaveJson);
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
            OnPropertyChanged(nameof(People));
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void LoadJson()
        {
            try
            {
                string filePath = _filePath;

                EnsureJsonFileExists();

                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"File not found: {filePath}");
                    return;
                }

                string json = File.ReadAllText(filePath);

                var personList = JsonConvert.DeserializeObject<List<Person>>(json);

                personList ??= [];

                People.Clear();
                foreach (var person in personList)
                {
                    People.Add(person);
                }
            }
            catch (Exception ex)
            {
                NavigationService.ShowMessage($"Error loading JSON.", "Error");
            }
        }

        private void SaveJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(People, Formatting.Indented);

                EnsureJsonFileExists();

                File.WriteAllText(_filePath, json);

                NavigationService.ShowMessage("JSON saved successfully.", "Success");
            }
            catch (Exception ex)
            {
                NavigationService.ShowMessage($"Error saving JSON: {ex.Message}", "Error");
            }
        }

        private void EnsureJsonFileExists()
        {
            string dir = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(_filePath))
            {
                string sourcePath = Path.Combine("Assets", "data.json");
                File.Copy(sourcePath, _filePath, overwrite: false);
            }
        }

        private void ToPersonCreation()
        {
            NavigationService.OpenUserCreationWindow(this);
        }
    }
}
