using System;
using System.Windows.Input;
using Xamarin.Forms;

using goiaba_mobile.Models;
using goiaba_mobile.Services;

namespace goiaba_mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {

        private GoiabaApi api;

        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
                ((Command)UpdateCommand).ChangeCanExecute();
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
                ((Command)UpdateCommand).ChangeCanExecute();
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged();
                ((Command)UpdateCommand).ChangeCanExecute();
            }
        }
        private string age;
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
                ((Command)UpdateCommand).ChangeCanExecute();
            }
        }

        public ICommand UpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ProfileViewModel()
        {
            this.api = new GoiabaApi();

            UpdateCommand = new Command(() =>
            {
                MessagingCenter.Send(new UserModel(), "UpdateCommand");
            },
           () =>
           {
               return ValidateProperties();

           });

            DeleteCommand = new Command(() =>
           {
               MessagingCenter.Send(this.Id, "DeleteCommand");
           });


        }

        public async void DeleteUser()
        {
            var result = await api.Destroy(this.id);

            if (result)
            {
                MessagingCenter.Send<String>("Successfully deleted", "SucessDelete");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailDelete");
            }

        }

        public async void UpdateUser()
        {

            var user = new UserModel()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                Surname = string.IsNullOrEmpty(Surname) ? "" : Surname,
                Age = Convert.ToInt32(this.Age)
            };

            var result = await api.Update(user);

            if (result)
            {
                MessagingCenter.Send<UserModel>(user, "SucessUpdate");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailUpdate");
            }

        }


        private bool ValidateProperties()
        {
            if (!string.IsNullOrEmpty(this.FirstName) && !this.FirstName.Equals(App.LOGGED_IN_USER.FirstName)
                && !string.IsNullOrEmpty(this.Age) && Convert.ToInt32(this.Age) > 0 && Convert.ToInt32(this.Age) <= 150
                || !string.IsNullOrEmpty(this.FirstName) && this.Age != App.LOGGED_IN_USER.Age.ToString() && !string.IsNullOrEmpty(this.Age)
                && Convert.ToInt32(this.Age) > 0 && Convert.ToInt32(this.Age) <= 150 || this.Surname != App.LOGGED_IN_USER.Surname &&
                !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.Age) && Convert.ToInt32(this.Age) > 0 && Convert.ToInt32(this.Age) <= 150)
            {
                return true;
            }

            return false;
        }

    }
}
