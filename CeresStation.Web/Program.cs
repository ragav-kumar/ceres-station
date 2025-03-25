using CeresStation.Dto;
using Microsoft.AspNetCore.Cors.Infrastructure;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: myAllowSpecificOrigins, policy =>
	{
		policy.WithOrigins("http://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

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
