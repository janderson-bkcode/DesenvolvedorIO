using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinhaPrimeiraAPI2.Data;
using MinhaPrimeiraAPI2.Config;
using MinhaPrimeiraAPI2.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Classe apiConfig.cs
builder.Services.WebApiConfig();
//Classe SwaggerConfig.cs
builder.Services.AddSwaggerConfig();
//Classe DependencyInjectionConfig.cs
builder.Services.ResolveDependencies();
builder.Services.AddMvc();
builder.Services.AddMvcCore();

//Configuração do DBContext e SQl 
builder.Services.AddDbContext<APIDbContext>(optionsAction: options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My Api v1");
    }); 


}
//Dentro do configure
//app.app.UseSwaggerConfig(provider);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
