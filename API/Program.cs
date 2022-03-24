using Application.Handlers.CommandHandlers;
using Core.Repositories;
using Core.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString= builder.Configuration.GetConnectionString("EmployeeDB");

builder.Services.AddDbContext<EmployeeContext>( m => m.UseSqlServer(connectionString), ServiceLifetime.Singleton);



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();









var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
