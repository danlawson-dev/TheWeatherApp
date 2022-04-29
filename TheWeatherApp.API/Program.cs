using TheWeatherApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add the OpenWeatherMap HTTP client service
builder.Services.AddHttpClient<IWeatherService, OpenWeatherMapService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["OpenWeatherMap:Endpoint"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();