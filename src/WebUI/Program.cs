using Application;
using Application.Common.Interfaces;
using Infrastructure;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// For Swagger Generation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameReviewDbContext>(options =>
{
    const string connectionStringPropertyName = "DefaultConnection";
    var connectionString = builder.Configuration.GetConnectionString(connectionStringPropertyName);
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IGameReviewDbContext>(provider => provider.GetRequiredService<GameReviewDbContext>());

// Dependencies from other layers
builder.Services.AddInfrastructure();
builder.Services.AddApplication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    // Configure swagger only on development
    app.UseSwagger();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
app.UseSwaggerUI();
app.Run();