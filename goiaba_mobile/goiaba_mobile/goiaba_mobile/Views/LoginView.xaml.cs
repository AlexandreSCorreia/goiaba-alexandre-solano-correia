using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using goiaba_mobile.Models;
using goiaba_mobile.ViewModels;

namespace goiaba_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            this.BindingContext = Startup.ServiceProvider.GetService<LoginViewModel>();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<UserModel>(this, "RegisterSeCommand",
                async (msg) =>
                {
                    await Shell.Current.GoToAsync("//login/registration");
                });

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin",
                async (exc) =>
                {
                    await DisplayAlert("login", exc.Message, "ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<UserModel>(this, "RegisterSeCommand");
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}