

using Application.Handlers.CommandHandlers;
using Core.Repositories;
using Infraestructure.Data;
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
builder.Services.AddDbContext<Context>(m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<UsuariosContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<CalendarioVacacionesContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<ProyectosContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<RolesContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<TecnicoProyectosContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<UsuarioProyectoContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<TipoDiaCalendarioContext>( m => m.UseSqlServer(connectionString));
//builder.Services.AddDbContext<EstadoCalendarioVacacionesContext>(m => m.UseSqlServer(connectionString));

//stuff automapper and mediatr
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateUsuarioHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateCalendarioVacacionesHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateRolesHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateProyectoHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateTecnicoProyectosHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateUsuarioProyectoHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateTipoDiaCalendarioHandler).GetTypeInfo().Assembly);


builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IProyectoRepository, ProyectoRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<ITecnicoProyectosRepository, TecnicoProyectosRepository>();
builder.Services.AddTransient<ICalendarioVacacionesRepository, CalendarioVacacionesRepository>();
builder.Services.AddTransient<IEstadoCalendarioVacacionesRepository, EstadoCalendarioVacacionesRepository>();
builder.Services.AddTransient<IUsuarioProyectoRepository, UsuarioProyectoRepository>();
builder.Services.AddTransient<ITipoDiaCalendarioRepository, TipoDiaCalendarioRepository>();









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
