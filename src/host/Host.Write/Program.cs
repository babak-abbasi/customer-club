using Domain.Repository;
using Repository.Write;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Repository.Write.Options>(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Service.CommandHandlers.Country.CreateCountryCommandHandler>());
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ElasticsearchClient>(config => {

    var options = config.GetRequiredService<IOptions<Repository.Write.Options>>();

    var settings = new ElasticsearchClientSettings(new Uri(options.Value.ElasticSearch.Url))
                .CertificateFingerprint(options.Value.ElasticSearch.FingerPrint)
                .Authentication(new BasicAuthentication(options.Value.ElasticSearch.UserName, options.Value.ElasticSearch.Password));

    return new ElasticsearchClient(settings);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();


app.Run();