using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CIS169IntroToNET.Data;
using CIS169IntroToNET.Model;

var builder = WebApplication.CreateBuilder(args);

// Alexander Meiners
// Due Date: May 15th, 2024
// C# .NET project
// Using a bit of HTML

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CIS169IntroToNETContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CIS169IntroToNETContext") ?? throw new InvalidOperationException("Connection string 'CIS169IntroToNETContext' not found.")));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    SeedData.Initialize(service);
}
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