using Tarea7.Components;
using Microsoft.EntityFrameworkCore;
using DetencionesDB.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DetencionesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DetencionesDB")));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
