using AutoMapper;
using BookStoreManagement.Common.Helpers;
using BookStoreManagement.Common.Interfaces;
using BookStoreManagement.Models;
using BookStoreManagement.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//===========================================================================

// sql server db connection
builder.Services.AddDbContext<BookStoreDBContext>(options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB"));
});

//add automapper
builder.Services.AddAutoMapper(typeof(ApplicationModelMapping));

builder.Services.AddTransient<IAuthorsRepository, AuthorsRepository>();
//===========================================================================

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
