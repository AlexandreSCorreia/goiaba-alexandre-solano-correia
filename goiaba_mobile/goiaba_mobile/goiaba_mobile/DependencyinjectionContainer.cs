using goiaba_mobile.Repositories;
using goiaba_mobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace goiaba_mobile
{
    public static class DependencyinjectionContainer
    {
        public static IServiceCollection ConfigureServices(this
            IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureViewModels(this
          IServiceCollection services)
        {
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ProfileViewModel>();
            services.AddTransient<RegistrationViewModel>();
            return services;
        }
    }
}
