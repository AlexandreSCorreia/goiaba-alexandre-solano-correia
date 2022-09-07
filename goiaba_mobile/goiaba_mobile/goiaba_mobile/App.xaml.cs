using Xamarin.Forms;

using goiaba_mobile.Models;

namespace goiaba_mobile
{
    public partial class App : Application
    {
        public static UserModel LOGGED_IN_USER;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<UserModel>(this, "Sucesslogin",
               async (user) =>
               {
                   LOGGED_IN_USER = user;
                   await Shell.Current.GoToAsync("//main");
               });

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
