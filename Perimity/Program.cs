using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Perimity.Data;

var builder = WebApplication.CreateBuilder(args);

// Database connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// MySQL DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ASP.NET Core Identity configuration with custom ApplicationUser and int Role Id
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        // For now we are not forcing confirmed email.
        // Later, when OTP email verification is completed, we can change this.
        options.SignIn.RequireConfirmedAccount = false;

        // Password rules
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;

        // Lockout rules
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Identity Razor Pages route
app.MapRazorPages();

// Seed roles and default admin user
DbSeeder.SeedRolesAndAdminAsync(app.Services).GetAwaiter().GetResult();

app.Run();