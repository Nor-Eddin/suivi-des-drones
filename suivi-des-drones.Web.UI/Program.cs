using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Application.Repositories;
using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
    //.AddRazorPagesOptions(option=>
    //option.Conventions.AddPageRoute("/CreateDrone", "/creation-drone")
    //);

builder.Services.AddDbContext<DronesDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DroneContext");
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IDroneDatalayer,SqlServerDroneDataLayer>();
builder.Services.AddScoped<IDroneRepository,DroneRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
