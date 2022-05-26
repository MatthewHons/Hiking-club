using System.Configuration;
using HikingProject.Areas.Identity.Data;
using HikingProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HikingProject.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

var builder = WebApplication.CreateBuilder(args);
//Facebook connection
var connectionString = builder.Configuration.GetConnectionString("HikingProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'HikingProjectContextConnection' not found.");

builder.Services.AddDbContext<HikingProjectContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<HikingProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HikingProjectContext>();;

//DB Hike connection
string connString = builder.Configuration.GetConnectionString("DefaultContext");

builder.Services.AddDbContext <DefaultContext> (options =>
    options.UseSqlServer(connString));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration["apis:facebook:id"];
    options.AppSecret = builder.Configuration["apis:facebook:secret"];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
