using ControlTowerDashboard.Interfaces;
using ControlTowerDashboard.Models.Settings;
using ControlTowerDashboard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.Configure<APIServer>(builder.Configuration.GetSection("APIServer"));

builder.Services.AddSession(); 
//builder.Services.AddDistributedMemoryCache(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
