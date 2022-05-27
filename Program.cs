using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrivyDash.Data;
using TrivyDash.Models;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsProduction())
{
    Console.WriteLine("is prod");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("Db1"))
    );
}
    else
{
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("Db1"))
    );
    // Console.WriteLine("Using InMem DbContext");
    // builder.Services.AddDbContext<AppDbContext>(opt =>
    //         opt.UseInMemoryDatabase("InMem"));
    
}
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Identity with the default UI
builder.Services.AddDefaultIdentity<ApplicationUser>(opt => opt.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
// IdentityServer with an additional AddApiAuthorization helper method that sets up some default ASP.NET Core conventions on top of IdentityServer
// This helper method configures IdentityServer to use our supported configuration. IdentityServer is a powerful and extensible framework for handling app security concerns. At the same time, that exposes unnecessary complexity for the most common scenarios. Consequently, a set of conventions and configuration options is provided to you that are considered a good starting point. Once your authentication needs change, the full power of IdentityServer is still available to customize authentication to suit your needs.
builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, AppDbContext>();
// Authentication with an additional AddIdentityServerJwt helper method that configures the app to validate JWT tokens produced by IdentityServer
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IReportRepo, ReportRepo>();
// Swagger/OpenAPI https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseMigrationsEndPoint();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// The authentication middleware that is responsible for validating the request credentials and setting the user on the request context
app.UseAuthentication();
// The IdentityServer middleware that exposes the OpenID Connect endpoints
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();