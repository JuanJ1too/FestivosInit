using Application.Extentions;
using Persistence.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.PersistenceServiceConfigurator(builder.Configuration);
builder.Services.ApplicationServiceConfigurator();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
