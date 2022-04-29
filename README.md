# TheWeatherApp

In order to use this application, retrieve an API Key from the 'Free' tier: https://openweathermap.org/price and then update the "OpenWeatherMap:APIKey" field in TheWeatherApp.API/appsettings.json file (the current value shows as INSERT_HERE).

## Running the app

.NET 6 SDK and Runtime can be downloaded from: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

If running through Visual Studio, ensure both TheWeatherApp.API and TheWeatherApp.Client projects are both set as startup projects.

On the other hand, if you publish to IIS, ensure the "TheWeatherApp:Endpoint" field in TheWeatherApp.Client/appsettings.json file is updated accordingly to where the TheWeatherApp.API project is hosted.