using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using goiaba_mobile.Models;
using goiaba_mobile.ViewModels;

namespace goiaba_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationView : ContentPage
    {
        private RegistrationViewModel registrationViewModel { get; set; }
        public RegistrationView()
        {
            InitializeComponent();

            this.registrationViewModel = Startup.ServiceProvider.GetService<RegistrationViewModel>(); ;
            this.BindingContext = this.registrationViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            MessagingCenter.Subscribe<UserModel>(this, "RegisterCommand",
                async (msg) =>
                {
                    var confirma = await DisplayAlert("Save Record", "Do you really want to send the registration?", "Yes", "No");
                    if (confirma)
                    {
                        this.registrationViewModel.SaveUser();
                    }

                });

            MessagingCenter.Subscribe<UserModel>(this, "SucessRegister",
             (user) =>
             {
                 MessagingCenter.Send<UserModel>(user, "Sucesslogin");
             });

            MessagingCenter.Subscribe<ArgumentException>(this, "FailRegister",
                (msg) =>
                {
                    DisplayAlert("Register", "Failed to register user! Please check the data and try again later!", "ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<UserModel>(this, "RegisterCommand");
            MessagingCenter.Unsubscribe<UserModel>(this, "SucessRegister");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FailRegister");
        }
    }
}