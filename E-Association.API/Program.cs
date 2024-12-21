using Domain.Entities.Securities;
using E_Association.Core;
using E_Association.Core.Domain.Middelware;
using E_Association.Infrastructure;
using E_Association.Infrastructure.Presitence.Data;
using Microsoft.EntityFrameworkCore;
using E_Association.Service;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Modules
builder.Services.AddInfrastructureModules();
builder.Services.AddPasswordConfigurations();
builder.Services.AddBusinessServicesModules();
builder.Services.AddCoreServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// register database 
var connetction = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(connetction));


// register Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                 .AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ExceptionGlobalHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
