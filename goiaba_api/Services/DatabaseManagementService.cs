using goiaba_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goiaba_api.Services
{
    public static class DatabaseManagementService
    {
          public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<AppDbContext>();
                serviceDb.Database.Migrate();
            }
            
        }
    }
}