

using Application.Handlers.CommandHandlers;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString= builder.Configuration.GetConnectionString("TFG_DB");

//DB Context
builder.Services.AddDbContext<EmployeeContext>(m => m.UseSqlServer(connectionString));
builder.Services.AddDbContext<UsuariosContext>( m => m.UseSqlServer(connectionString));
builder.Services.AddDbContext<CalendarioVacacionesContext>( m => m.UseSqlServer(connectionString));

//stuff automapper and mediatr
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateUsuarioHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateCalendarioVacacionesHandler).GetTypeInfo().Assembly);


builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ICalendarioVacacionesRepository, CalendarioVacacionesRepository>();









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
