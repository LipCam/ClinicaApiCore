using ClinicaApiCore.DB;
using ClinicaApiCore.Repositories;
using ClinicaApiCore.Repositories.Imp;
using ClinicaApiCore.Services;
using ClinicaApiCore.Services.Imp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ApiRestConnectionString")));

builder.Services.AddScoped<IMedicosService, MedicosService>();
builder.Services.AddTransient<IMedicosRepository, MedicosRepository>();

builder.Services.AddScoped<IProcedimentosService, ProcedimentosService>();
builder.Services.AddTransient<IProcedimentosRepository, ProcedimentosRepository>();

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
