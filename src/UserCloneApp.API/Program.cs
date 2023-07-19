using Autofac;
using Autofac.Extensions.DependencyInjection;
using UserCloneApp.API.Extensions.Middlewares;
using UserCloneApp.API.Extensions.Registrations;
using UserCloneApp.Application.Extensions.Modules;
using UserCloneApp.Application.Extensions.Registrations;
using UserCloneApp.Infrastructure.Extensions.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For dependency injection with Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new DependecyInjectionModule()));

// Extends services with infrastructure layer services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Extends services with application layer services
builder.Services.AddApplicationServices(builder.Configuration);

// Extends services with api layer services
builder.Services.AddAPIServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Allow all CORS
app.UseCors("AllowAll");

// Use custom logger middleware to manage logs and exception responses
app.UseMiddleware<LoggerMiddleware>();

// Enables the authentication and authorization mechanism in the project
app.UseAuthentication().UseAuthorization();

app.MapControllers();

app.Run();
