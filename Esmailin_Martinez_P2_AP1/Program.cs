using Esmailin_Martinez_P2_AP1.Components;
using Esmailin_Martinez_P2_AP1.DAL;
using Esmailin_Martinez_P2_AP1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//
var ConSrt = builder.Configuration.GetConnectionString("SqlConStr");

//Agregar contexto al builder con ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConSrt));

//Inyectar del service
builder.Services.AddScoped<Service>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
