using Domain.Repository;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Helper.ExceptionHandling.Handler;
using Helper.ExceptionHandling.Types;
using Host.Write.CustomMiddlewares;
using Host.Write.Filters.ExceptionFilters;
using Microsoft.Extensions.Options;
using Repository.Write;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Repository.Write.Options>(builder.Configuration);
builder.Services.AddSingleton<CustomExceptionRegistery>(options =>
{
    CustomExceptionRegistery registery = new();
    registery.Register<ResponsiveException>(new ResponsiveExceptionHandler());
    registery.Register<LoggableException>(new LoggableExceptionHandler());

    return registery;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Service.CommandHandlers.Country.CreateCountryCommandHandler>());
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ElasticsearchClient>(config =>
{

    var options = config.GetRequiredService<IOptions<Repository.Write.Options>>();

    var settings = new ElasticsearchClientSettings(new Uri(options.Value.ElasticSearch.Url))
                .CertificateFingerprint(options.Value.ElasticSearch.FingerPrint)
                .Authentication(new BasicAuthentication(options.Value.ElasticSearch.UserName, options.Value.ElasticSearch.Password));

    return new ElasticsearchClient(settings);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();