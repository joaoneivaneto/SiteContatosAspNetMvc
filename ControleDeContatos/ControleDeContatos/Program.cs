using ControleDeContatos.Interface;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<BancoContext>
    (options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
