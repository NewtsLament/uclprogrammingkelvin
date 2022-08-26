using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurfBoardManager.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SurfBoardManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SurfBoardManagerContext") ?? throw new InvalidOperationException("Connection string 'SurfBoardManagerContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddMvcLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
var supportedCultures = new[] { "en-US" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
});

var app = builder.Build();

var supportedCultures = new[] { "en-US" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

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

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
SeedData.Initialize(app.Services.CreateScope().ServiceProvider);
app.Run();
