using CloudAppi.Models;
using CloudAppi.Repository;
using CloudAppi.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CountriesContext>(opt => opt.UseInMemoryDatabase("CountriesContext"));


ExternalServices externalServices = builder.Configuration.GetSection("ExternalServices").Get<ExternalServices>();
builder.Services.AddSingleton<ExternalServices>(externalServices);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IRestCountriesService, RestCountriesService>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//NLog: Setup NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
