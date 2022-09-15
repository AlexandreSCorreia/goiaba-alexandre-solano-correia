using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

using goiaba_mobile.Models;
using goiaba_mobile.Services;
using goiaba_mobile.Repositories;

namespace goiaba_mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private readonly UserService userService;

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public ICommand RegisterSeCommand { get; private set; }


        public LoginViewModel(IUserRepository userRepository)
        {
            this.userService = new UserService(userRepository);

            try
            {
                EntrarCommand = new Command(async () =>
                {
                    var user = await this.userService.Find(this.Id);

                    if (!string.IsNullOrEmpty(user.FirstName))
                    {
                        MessagingCenter.Send<UserModel>(user, "Sucesslogin");
                    }
                    else
                    {
                        MessagingCenter.Send<LoginException>(new LoginException("Invalid Id, please enter a valid Id to access the application.", null), "FalhaLogin");
                    }
                },
                () =>
                {
                    return !string.IsNullOrEmpty(id);
                });

                RegisterSeCommand = new Command(() =>
                {
                    MessagingCenter.Send<UserModel>(new UserModel(), "RegisterSeCommand");
                });
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<LoginException>(new
                             LoginException("Communication error with the server.", exc), "FalhaLogin");
            }

        }

    }
}
