using Microsoft.EntityFrameworkCore;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Application.Persistence;
using RemindMe.Application.Persistence.Repositories;
using RemindMe.Application.Persistence.Services;
using RemindMe.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json");

builder.Services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("postgreSqlConnection")));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

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

app.Run();
