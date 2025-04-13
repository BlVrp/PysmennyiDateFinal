using CommunityToolkit.Mvvm.Input;
using PysmennyiDateFinal.Models;
using PysmennyiDateFinal.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PysmennyiDateFinal.ViewModels
{
    public class PersonCreationViewModel
    {
        private MainViewModel _mainViewModel;

        private string? _name;
        private string? _surname;
        private string? _email;
        private DateTime? _birthDate;

        public event EventHandler RequestClose;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value; OnPropertyChanged(nameof(Name));
                CreatePersonCommand.NotifyCanExecuteChanged();
            }
        }
        public string? Surname
        {
            get { return _surname; }
            set
            {
                _surname = value; OnPropertyChanged(nameof(Surname));
                CreatePersonCommand.NotifyCanExecuteChanged();
            }
        }
        public string? Email
        {
            get { return _email; }
            set
            {
                _email = value; OnPropertyChanged(nameof(Email));
                CreatePersonCommand.NotifyCanExecuteChanged();
            }
        }
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
                CreatePersonCommand.NotifyCanExecuteChanged();
            }
        }


        public RelayCommand CreatePersonCommand { get; }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public async Task CreatePerson(string? name, string? surname, string? email, DateTime? birthDate)
        {
            try
            {
                if (!CanExecuteCreatePerson())
                {
                    NavigationService.ShowMessage("Please fill all fields", "Error");
                    return;
                }
                var person = await Task.Run(() => new Person(name, surname, email, birthDate.Value));
                _mainViewModel.AddPerson(person);
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
               
                NavigationService.ShowMessage(e.Message, "Error");
            }
        }

        public bool CanExecuteCreatePerson()
        {
            return !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname) && !string.IsNullOrEmpty(_email) && _birthDate != null;
        }

        public PersonCreationViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            CreatePersonCommand = new RelayCommand(async () => await CreatePerson(Name, Surname, Email, BirthDate), () => CanExecuteCreatePerson());
        }


    }
}
