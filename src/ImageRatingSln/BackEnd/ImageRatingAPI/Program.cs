using ImageRatingAPI.Business;
using ImageRatingAPI.Data;
using ImageRatingAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Configuration
var config = builder.Configuration;//.SetBasePath(Directory.GetCurrentDirectory());

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("ApplicationDb"), sqlServerOptions => sqlServerOptions.CommandTimeout(int.MaxValue)), ServiceLifetime.Transient);

// Add Servicess
builder.Services.AddTransient<FileService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ImageService>();
builder.Services.AddTransient<UserImageRatingService>();

// Add Business Functionalities
builder.Services.AddTransient<BusinessFunctionalities>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
