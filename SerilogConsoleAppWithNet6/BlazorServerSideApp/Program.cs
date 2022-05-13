using BlazorServerSideApp.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)    
    .WriteTo.Console()
    .WriteTo.Logger(lc => lc
                    //.Filter.ByIncludingOnly(" @l = 'Debug' or @l = 'Information' or @l = 'Warning'")
                    .Filter.ByIncludingOnly(l => l.Level == LogEventLevel.Warning || l.Level == LogEventLevel.Information || l.Level == LogEventLevel.Debug)
                    .WriteTo.File("Logs/log-Information-.log", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(lc => lc
                    //.Filter.ByIncludingOnly(" @l = 'Error' or @l = 'Fatal'")
                    .Filter.ByIncludingOnly(l => l.Level == LogEventLevel.Error || l.Level == LogEventLevel.Fatal)
                    .WriteTo.File("Logs/log-Error-.log", rollingInterval: RollingInterval.Day))
    .CreateLogger();

Log.Information("Starting up");


Serilog.Log.Information("Starting application");
Serilog.Log.Error("Error");
Serilog.Log.Fatal("Fatal");
Serilog.Log.Debug("Debug");

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
