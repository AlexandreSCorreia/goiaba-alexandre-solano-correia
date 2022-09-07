using goiaba_api.Models;
using goiaba_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//teste
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//fim teste


// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var conexao = builder.Configuration.GetConnectionString("DefaultConnection");
//var conexao = builder.Configuration.GetConnectionString("DefaultConnectionTest");

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(conexao));


var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInitialisation(app);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
