using Domain.Repository;
using Repository.Write;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Options>(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Service.CommandHandlers.Country.CreateCountryCommandHandler>());
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();


app.Run();