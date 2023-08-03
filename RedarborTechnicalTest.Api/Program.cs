using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RedarborTechnicalTest.Api.Middlewares;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Commands;
using RedarborTechnicalTest.Core.Services.Querys;
using RedarborTechnicalTest.Infrastructure.Data;
using RedarborTechnicalTest.Infrastructure.Repositories;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

#region Inyectionvalidators
builder.Services.AddValidatorsFromAssembly(typeof(GetEmployeeQuery).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetEmployeeByIdQuery).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(UpdateEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(DeleteEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.Load("RedarborTechnicalTest.Core"));
#endregion

#region Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
#endregion

#region ParametersDb
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_SA_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID={dbUser}; Password={dbPassword};Integrated Security=false;Encrypt=False";
#endregion
builder.Services.AddDbContext<ApplicationEmployeeDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"])),
        };
    });

builder.Services.AddControllers();

builder.Services.AddMvc();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }
