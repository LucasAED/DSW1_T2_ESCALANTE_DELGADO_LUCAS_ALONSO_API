using Library.Application;
using Library.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 1. Inyectar nuestras capas (Application e Infrastructure)
// Esto conecta la BD y los Servicios automáticamente
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// 2. Configurar CORS (Para que el Frontend HTML funcione después)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. Activar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();