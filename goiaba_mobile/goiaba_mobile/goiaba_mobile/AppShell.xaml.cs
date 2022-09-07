using goiaba_mobile.Views;
using Xamarin.Forms;

namespace goiaba_mobile
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("registration", typeof(RegistrationView));
        }
    }
}
