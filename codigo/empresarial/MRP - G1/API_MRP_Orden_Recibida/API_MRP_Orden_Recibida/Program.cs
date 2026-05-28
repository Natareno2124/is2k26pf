using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Newtonsoft
builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API_MRP_Orden_Recibida",
        Version = "v1"
    });
});

var app = builder.Build();

// Swagger habilitado siempre
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_MRP_Orden_Recibida v1");
});

app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:5000");