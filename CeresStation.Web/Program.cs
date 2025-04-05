using CeresStation.Core;
using CeresStation.GraphQl;
using CeresStation.Simulation;
using CeresStation.TickService;
using Microsoft.EntityFrameworkCore;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// StationContext DI
builder.Services.AddDbContext<StationContext>(options => options
	.UseSqlite($"Data source={StationContext.DefaultDbPath}")
	.UseLazyLoadingProxies()
);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen();

// Setup TickService and simulations
builder.Services
	.AddSingleton<TickRegistry>()
	.AddHostedService<TickService>()
	.AddSimulation();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: myAllowSpecificOrigins, policy =>
	{
		policy.WithOrigins("http://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services
	.AddGraphQLServer()
	.AddCeresStationGraphQl();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(myAllowSpecificOrigins);

app.Run();
