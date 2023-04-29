using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Application.Repositories;
using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Infrastructure.Web.Middlewares;
using Microsoft.AspNetCore.Identity;
using suivi_des_drones.Core.Infrastructure;
using suivi_des_drones.Core.Infrastructure.Web.Constrains;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//.AddRazorPagesOptions(option=>
//option.Conventions.AddPageRoute("/CreateDrone", "/creation-drone")
//);
var connectionString = builder.Configuration.GetConnectionString("DroneContext");

builder.Services.AddDbContext<DronesDbContext>(options =>
{
    
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<AuthenticationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthenticationContext>();
builder.Services.AddDbContext<AuthenticationContext>(options =>options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDroneDatalayer, SqlServerDroneDataLayer>();
builder.Services.AddScoped<IUserDataLayer, SqlServerUserDatalayer>();
builder.Services.AddScoped<IDroneRepository, DroneRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});

builder.Services.Configure<RouteOptions>(options => {
    options.ConstraintMap.Add("matconst",typeof(MatriculeRouteConstrains));
    });

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

app.UseSession();
app.UseAuthentication();;
app.UseAuthorization();

//Deuxi�me version de config de session "Middleware"(mis en commentaire pour utilisations avec identity)
//app.UseRedirectIfNotConnected();

//premi�re version de config de session "Middleware"
//app.Use(async (context, next) =>
//{
//    var id = context.Session.GetInt32("UserId");
//    var isLoginPage = context.Request.Path.Value?.ToLower().Contains("login");

//    if (!id.HasValue && (!isLoginPage.HasValue || !isLoginPage.Value))
//    {
//        context.Response.Redirect("/Login");
//        return;
//    }
//    await next.Invoke(context);
//});

app.MapRazorPages();

app.Run();
