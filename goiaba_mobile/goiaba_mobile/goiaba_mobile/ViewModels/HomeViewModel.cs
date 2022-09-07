using System.Windows.Input;
using Xamarin.Forms;

namespace goiaba_mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; }


        private string welcome;
        public string Welcome
        {
            get
            {
                return welcome;
            }
            set
            {
                welcome = value;
                OnPropertyChanged();
            }
        }


        public HomeViewModel()
        {
            var user = App.LOGGED_IN_USER;

            Welcome = $"Welcome\n{user.FirstName} {user.Surname}";

            LogoutCommand = new Command(() =>
            {
                Application.Current.MainPage = new AppShell();
            });

        }
    }
}
