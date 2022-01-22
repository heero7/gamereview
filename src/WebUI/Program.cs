using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GameReviewDbContext>(options =>
{
    const string connectionStringPropertyName = "DefaultConnection";
    var connectionString = builder.Configuration.GetConnectionString(connectionStringPropertyName);
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IGameReviewDbContext>(provider => provider.GetRequiredService<GameReviewDbContext>());

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();