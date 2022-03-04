using Autofac;
using Autofac.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Oponeo.Controllers;
using Oponeo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
assemblies.Add(typeof(OponeoMarkerControllers).Assembly);
assemblies.Add(typeof(MockRepository).Assembly);
// Add services to the container.


builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddAutoMapper(assemblies);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

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

app.MapControllers();

app.Run();