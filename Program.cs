using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using aspnet_core_integration.Filters;
using aspnet_core_integration.Validators.Invoice;
using Serilog;
using aspnet_core_integration.Services;
using aspnet_core_integration.Services.Implements;
using aspnet_core_integration.Infrastructure.Http;
using aspnet_core_integration.Infrastructure.ExternalServices.OlimPush;
using aspnet_core_integration.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services
    .AddControllers(options =>
     {
         options.Filters.Add<ValidationActionFilter>();
     })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });


// Bind settings
builder.Services.Configure<OlimPushSettings>(
    builder.Configuration.GetRequiredSection("OlimPushApi"));

// HttpClient generico para API externa OlimPush
builder.Services.AddHttpClient<IHttpClientService, HttpClientService>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<OlimPushSettings>>().Value;

    var logger = sp.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Configuring HttpClient for OlimPush. BaseUrl: {BaseUrl}",
        settings.BaseUrl);

    client.BaseAddress = new Uri(settings.BaseUrl);
    client.DefaultRequestHeaders.Add("olimpush-token", settings.AccessToken);
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});

// aqui podrias agregar nuevos clientes builder.Services.AddHttpClient


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.DisableDataAnnotationsValidation = true;
});

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(
            "Logs/app-.log",
            rollingInterval: RollingInterval.Day
        );
});

builder.Services.AddValidatorsFromAssemblyContaining<InvoicePayloadDtoValidator>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IOlimPushApiService, OlimPushApiService>();

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
