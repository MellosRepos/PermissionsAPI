using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nest;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddConsole();

ConfigureServices(builder.Services, builder.Configuration, builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration, ILogger<Program> logger)
{
    services.AddDbContext<SQLServerDBContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IPermissionsServices, PermissionServices>();
    services.AddScoped<IPermissionsRepository, PermissionsRepository>();
    var elasticConfig = configuration.GetSection("Elasticsearch");
    services.AddSingleton<IElasticClient>(x => {
        var settings = new ConnectionSettings(new Uri($"http://{elasticConfig["Uri"]}:9200"))
            .DefaultIndex("permissions")
            .DefaultMappingFor<Permissions>(m => m);
        logger.LogInformation($"Elasticsearch settings: URI: {elasticConfig["Uri"]}, Index: permissions");
        return new ElasticClient(settings);
    });
}
