using Microsoft.EntityFrameworkCore;
using Persistence;
using SneakPeek.Components;
using Domain.Interfaces;
using Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add Aspire service defaults
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("MyHttpClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5098");
});

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Movies"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}
// Enable Aspire service defaults
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapControllers();

app.Run();
