using Service.Read.Repository;
using Repository.Read;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Options;
using Helper.ExceptionHandling.Handler;
using Helper.ExceptionHandling.Types;
using Host.Read.Filters.ExceptionFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Repository.Read.Options>(builder.Configuration);
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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Service.QueryHandlers.Country.GetByIdQueryHandler>());
builder.Services.AddScoped<ICountryReadRepository, CountryReadRepository>();
builder.Services.AddScoped<IProvinceReadRepository, ProvinceReadRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ElasticsearchClient>(config => {

    var options = config.GetRequiredService<IOptions<Repository.Read.Options>>();

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

app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();


app.Run();