using System;
using System.Windows.Input;
using Xamarin.Forms;

using goiaba_mobile.Models;
using goiaba_mobile.Services;
using goiaba_mobile.Repositories;

namespace goiaba_mobile.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private UserModel user { get; set; }
        private readonly UserService userService;

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
                ((Command)RegisterCommand).ChangeCanExecute();
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
                ((Command)RegisterCommand).ChangeCanExecute();
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
                ((Command)RegisterCommand).ChangeCanExecute();
            }
        }


        public ICommand RegisterCommand { get; set; }

        public ICommand CancelRegister { get; set; }

        public RegistrationViewModel(IUserRepository userRepository)
        {
            this.userService = new UserService(userRepository);

            RegisterCommand = new Command(() =>
            {
                this.user = new UserModel()
                {
                    FirstName = this.FirstName,
                    Surname = string.IsNullOrEmpty(Surname) ? "" : Surname,
                    Age = Convert.ToInt32(this.Age)
                };

                MessagingCenter.Send(this.user, "RegisterCommand");
            },
            () =>
            {
                return ValidateProperties();

            });

            CancelRegister = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//login");
            });
        }

        public async void SaveUser()
        {
            try
            {
                var user = await userService.Create(this.user);

                if (!string.IsNullOrEmpty(user.FirstName))
                {
                    MessagingCenter.Send<UserModel>(user, "SucessRegister");
                }
                else
                {
                    MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailRegister");
                }
            } 
            catch (Exception ex)
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(ex.Message), "FailRegister");
            }

        }

        private bool ValidateProperties()
        {
            if (!string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.Age) &&
                Convert.ToInt32(this.Age) > 0 && Convert.ToInt32(this.Age) <= 150)
            {
                return true;
            }

            return false;
        }
    }
}
