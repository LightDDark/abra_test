using abra_test.Models;
using abra_test.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PetDatabaseSettings>(
    builder.Configuration.GetSection("PetDatabase"));

builder.Services.AddSingleton<PetService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
