using BeyondCreator.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeyondCreator.Models;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BeyondCreatorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeyondCreatorContext") ?? throw new InvalidOperationException("Connection string 'BeyondCreatorContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("BeyondCreatorContext");
builder.Services.AddDbContext<BeyondCreatorContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>
    (options => { options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<BeyondCreatorContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
        .Build();
});
var app = builder.Build();

//Контекст автозаполнения базы тестовым значением, если данных в базе нет.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initilize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "Character_PDF", pattern: "{controller=Characters}/{action=Details}/{id?}");
app.MapRazorPages();

app.Run();
