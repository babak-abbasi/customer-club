using Domain.Read.Repository;
using Repository.Read;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Options>(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Service.QueryHandlers.Country.GetByIdCountryQueryHandler>());
builder.Services.AddScoped<ICountryReadRepository, CountryReadRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();


app.Run();