using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RedarborTechnicalTest.Api.Middlewares;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Commands;
using RedarborTechnicalTest.Core.Services.Querys;
using RedarborTechnicalTest.Infrastructure.Data;
using RedarborTechnicalTest.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidatorsFromAssembly(typeof(GetEmployeeQuery).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetEmployeeByIdQuery).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(UpdateEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(DeleteEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.Load("RedarborTechnicalTest.Core"));

#region Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
#endregion
#region ParametersDb
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa; Password={dbPassword}";
#endregion
builder.Services.AddDbContext<ApplicationEmployeeDbContext>(opt =>
//opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

opt.UseSqlServer(connectionString));
// opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

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
app.UseRouting();
app.UseMiddleware<ErrorHandler>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
