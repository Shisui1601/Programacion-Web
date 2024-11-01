using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tarea 6",
        Version = "v1",
        Description = "Documentacion de mi API Swagger"

    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MI API v1");
        c.RoutePrefix = string.Empty;
    });
}

String Suma(int a, int b){
    return $"la suma de {a} y {b} es {a+b}";
}




app.MapGet("/saludo", (string name) => $"Hello {name}!");

app.MapGet("/Suma", (int a, int b) => Suma(a,b));

app.MapGet("/noticias", Paso1.Ejecutar);

app.MapPost("/registro_usuario", (Usuario u) => ManejadorUsuario.Registro(u));

app.MapPost("/iniciar_sesion", (DatoLogin dl) => ManejadorUsuario.IniciarSesion(dl));
app.MapPost("/registro_incidencia", (Incidencia i) => ManejadorUsuario.RegistroIncidencia(i));


app.Run();
