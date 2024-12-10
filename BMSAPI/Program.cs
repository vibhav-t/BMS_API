using BMSAPI.Entities;
using BMSAPI.Extensions;
using BMSAPI.Repository;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.Commands.Handlers;
using BMSAPI.Repository.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "blog.json");
builder.Services.AddSingleton(new JsonFileService(filePath));
builder.Services.AddApplicationServices();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateBlogCommandHandler>());
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
