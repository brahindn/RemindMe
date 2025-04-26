using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Domain.Entities;
using RemindMe.Infrastructure.Persistence;
using RemindMe.Infrastructure.Persistence.Repositories;
using RemindMe.Infrastructure.Persistence.Services;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json");

var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.MongoDB(databaseUrl: builder.Configuration.GetConnectionString("MongoDbConnection"), collectionName: "RemindMeLogs")
    .CreateLogger();

builder.Services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddSingleton<ILogger>(loggerConfiguration);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
        
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<RepositoryContext>()
    .AddApiEndpoints();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
