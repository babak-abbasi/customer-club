using Domain.Repository;
using Helper.ExceptionHandling.Handler;
using Helper.ExceptionHandling.Types;
using Host.Write.CustomMiddlewares;
using Host.Write.Filters.ExceptionFilters;
using Microsoft.EntityFrameworkCore;
using Repository.Write;
using Repository.Write.EFContext;
using Service.Write;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Options>(builder.Configuration);
builder.Services.AddSingleton(options =>
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
builder.Services.AddDbContext<EFDBContext>((sp, options) =>
{
    var dbOptions = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<Options>>().Value;

    options.UseNpgsql(dbOptions.ConnectionStrings.WriteDb);
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