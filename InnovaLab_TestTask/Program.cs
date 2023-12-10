using InnovaLab_TestTask.Services.Abstract;
using Microsoft.OpenApi.Models;
using InnovaLab_TestTask.Services;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
	.CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<IHttpClientService, HttpClientService>();

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Innoval Lab Test Task", Version = "v1" });
});

var app = builder.Build();

app.UseExceptionHandler(appError =>
{
	appError.Run(async context =>
	{
		var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
		if (contextFeature != null)
		{
			Log.Error($"Global error handler: {contextFeature.Error}");
		}
	});
});

app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseSwagger();

app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
