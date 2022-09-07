using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using goiaba_mobile.Models;

namespace goiaba_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class HomeView : ContentPage
    {

        public HomeView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<UserModel>(this, "UpdatedData",
                 (msg) =>
                 {
                     App.LOGGED_IN_USER.FirstName = msg.FirstName;
                     App.LOGGED_IN_USER.Surname = msg.Surname;
                     App.LOGGED_IN_USER.Age = msg.Age;

                     lblWelcome.Text = $"Welcome\n{msg.FirstName} {msg.Surname}";

                 });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<UserModel>(this, "UpdatedData");
        }
    }
}