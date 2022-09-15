using goiaba_mobile.Models;
using goiaba_mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace goiaba_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        private ProfileViewModel profileViewModel { get; set; }

        public ProfileView()
        {
            InitializeComponent();

            this.profileViewModel = Startup.ServiceProvider.GetService<ProfileViewModel>();
            this.BindingContext = this.profileViewModel;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            UpdateData();

            MessagingCenter.Subscribe<UserModel>(this, "UpdateCommand",
              async (msg) =>
              {
                  var confirma = await DisplayAlert("Update Register", "Do you really want to send the changes?", "Yes", "No");
                  if (confirma)
                  {
                      this.profileViewModel.UpdateUser();
                  }
              });

            MessagingCenter.Subscribe<UserModel>(this, "SucessUpdate",
                async (msg) =>
                {
                    await Shell.Current.GoToAsync("//main");
                    MessagingCenter.Send<UserModel>(msg, "UpdatedData");
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FailUpdate",
                   (msg) =>
                   {
                       DisplayAlert("Update", $"Failed to update user! Please check the data and try again later!\n{msg}", "ok");
                   });

            MessagingCenter.Subscribe<String>(this, "DeleteCommand",
                async (msg) =>
                {
                    var confirma = await DisplayAlert("Delete Account", "Do you really want to delete your account?", "Yes", "No");
                    if (confirma)
                    {
                        this.profileViewModel.DeleteUser();
                    }
                });

            MessagingCenter.Subscribe<String>(this, "SucessDelete",
                (msg) =>
                {
                    Application.Current.MainPage = new AppShell();
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FailDelete",
                   (msg) =>
                   {
                       DisplayAlert("Delete", $"Failed to delete user account! If the error persists, please try again later!\n{msg}", "ok");
                   });


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UpdateData();


            MessagingCenter.Unsubscribe<UserModel>(this, "UpdateCommand");
            MessagingCenter.Unsubscribe<UserModel>(this, "SucessUpdate");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FailUpdate");

            MessagingCenter.Unsubscribe<String>(this, "DeleteCommand");
            MessagingCenter.Unsubscribe<String>(this, "SucessDelete");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FailUDelete");
        }

        private void UpdateData()
        {
            entId.Text = App.LOGGED_IN_USER.Id;
            entFirstName.Text = App.LOGGED_IN_USER.FirstName;
            entSurname.Text = App.LOGGED_IN_USER.Surname;
            entAge.Text = App.LOGGED_IN_USER.Age.ToString();
        }
    }
}