using PysmennyiDateFinal;
using PysmennyiDateFinal.ViewModels;
using System.Windows;

namespace PysmennyiDateFinal.Services
{
    public static class NavigationService
    {
        public static void OpenUserCreationWindow(MainViewModel model)
        {
            var window = new UserCreationWindow(new PersonCreationViewModel(model));
          
            window.Show();
        }

        public static void ShowMessage(string message, string title="Error")
        {
            MessageBox.Show(message, title);
        }
    }
}
