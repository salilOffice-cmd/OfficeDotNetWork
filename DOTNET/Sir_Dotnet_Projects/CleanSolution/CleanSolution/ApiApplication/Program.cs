using System;
using System.Reflection;
using ApiApplication.Controllers;
using Application;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContgext>(options =>
    options.UseSqlServer(
        builder.
        Configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly(typeof(ApplicationDbContgext).Assembly.FullName)));

builder.Services
    .AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContgext>()
    );


builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
