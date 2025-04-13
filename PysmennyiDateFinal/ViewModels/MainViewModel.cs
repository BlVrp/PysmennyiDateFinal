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
using System.Windows.Data;

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
                PeopleView = CollectionViewSource.GetDefaultView(_people);
                PeopleView.Filter = FilterPeople;
            }
        }

        private string _surnameFilter = string.Empty;
        public string SurnameFilter
        {
            get { return _surnameFilter; }
            set
            {
                _surnameFilter = value;
                OnPropertyChanged(nameof(SurnameFilter));
                PeopleView.Refresh();
            }
        }

        

        private ICollectionView? _peopleView;
        public ICollectionView PeopleView
        {
            get => _peopleView!;
            private set
            {
                _peopleView = value;
                OnPropertyChanged(nameof(PeopleView));
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

        private bool FilterPeople(object obj)
        {
            if (obj is Person person)
            {

                if (string.IsNullOrEmpty(SurnameFilter))
                    return true;

                return person.Surname.Contains(SurnameFilter, StringComparison.OrdinalIgnoreCase);
            }
            return false;
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
                PeopleView = CollectionViewSource.GetDefaultView(_people);
                PeopleView.Filter = FilterPeople;
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
