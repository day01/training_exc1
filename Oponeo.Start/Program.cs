using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Oponeo.Contracts;
using Oponeo.Controllers;
using Oponeo.Infrastructure;
using Oponeo.Start.Configurations;
using Oponeo.Start.Middleware;

var builder = WebApplication.CreateBuilder(args);

var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
assemblies.Add(typeof(OponeoMarkerControllers).Assembly);
assemblies.Add(typeof(MockRepository).Assembly);

// configure options
var section = builder.Configuration.GetSection(nameof(OponeoSettings));
builder.Services.Configure<OponeoSettings>(section);

// binding if we need it
var settings = new OponeoSettings();
section.Bind(settings);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => { options.SerializerSettings.Converters.Add(new StringEnumConverter()); })
    .AddFluentValidation(options => { options.RegisterValidatorsFromAssembly(typeof(ContractMark).Assembly); });

builder.Services.AddAutoMapper(assemblies);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

// dbcontext
builder.Services.AddDbContext<OponeoContext>(
    // options => options.UseNpgsql(settings.ConnectionString));
    options => options.UseSqlServer(
        settings.ConnectionString,
        x => x.MigrationsAssembly("Oponeo.Migrations")));

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
        options.RegisterAssemblyModules(assemblies.ToArray())));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(CustomLoggingMiddleware.Handle());

app.MapControllers();

app.Run();