using Microsoft.Extensions.Configuration;
using WellsFargo_BusinessEntities.Interfaces;
using WellsFargo_Dapper_DatabaseLogic;
using WellsFargo_Dapper_DatabaseLogic.DbConnect;
using WellsFargo_Dapper_ServiceLayer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();
builder.Services.Configure<ConnectConfiguration>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//var configuration = builder.Configuration;
//builder.Configure<CprConfiguration>(Configuration.GetSection("ConnectionStrings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
