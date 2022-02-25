using Autofac;
using Autofac.Extensions.DependencyInjection;
using Oponeo.Controllers;
using Oponeo.Domain;
using Oponeo.Infastructure;
using Oponeo.Start.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
assemblies.Add(typeof(OfferControllerMarker).Assembly);
builder.Services.AddAutoMapper(assemblies);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddScoped<IOfferRepository, MockOfferRepository>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
{
    options.RegisterAssemblyModules(assemblies.ToArray());
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(CustomLoggingMiddleware.Handle());

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