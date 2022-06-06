using Blazored.Toast;
using Localization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using SchneiderHolzBlazorApp.Areas.Identity;
using SchneiderHolzBlazorApp.Data;

namespace SchneiderHolzBlazorApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services
            .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
        builder.Services.AddScoped(x =>
        {
            return new HttpClient { BaseAddress = new Uri("http://localhost:4000/api") };
        });
        builder.Services.AddScoped<ILocalizer, Localizer>();
        builder.Services.AddBlazorTable();
        builder.Services.AddBlazoredToast();
        builder.Services.AddBlazoredModal();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var defaultLocale = builder.Configuration.GetValue<string>("Locale");
        string[] supportedLocales = { defaultLocale, "de-DE", "en-US", "it-IT", "fr-FR" };
        var localizeOptions = new RequestLocalizationOptions().SetDefaultCulture(defaultLocale).AddSupportedCultures(supportedLocales).AddSupportedUICultures(supportedLocales);
        app.UseRequestLocalization(localizeOptions);

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}