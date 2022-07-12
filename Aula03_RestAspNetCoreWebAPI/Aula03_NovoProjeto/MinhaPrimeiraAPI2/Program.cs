using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinhaPrimeiraAPI2.Data;
using MinhaPrimeiraAPI2.Config;
using MinhaPrimeiraAPI2.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MinhaPrimeiraAPI2.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Classe apiConfig.cs
//builder.Services.WebApiConfig();
//Classe SwaggerConfig.cs
builder.Services.AddSwaggerConfig();
//Classe DependencyInjectionConfig.cs
builder.Services.ResolveDependencies();
builder.Services.AddMvc();
builder.Services.AddMvcCore();

//kisslog
builder.Services.AddKissLogConfig();

//Configuração do DBContext e SQl 
builder.Services.AddDbContext<APIDbContext>(optionsAction: options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection")));

//Configuração HealthCheck
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection"),name:"Banco");

//Configurando a interface gráfica e o armazenamento do histórico
builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(5);
    options.MaximumHistoryEntriesPerEndpoint(10);
    options.AddHealthCheckEndpoint("API com Health Checks", "/api/hc-ui");
})
.AddInMemoryStorage();   //Aqui adicionamos o banco em memória

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

//Usando Midleware feito na pasta extensions para quando houver Exceptions na controller gerará Response 500 
//Ver -> /Extensions/ExceptionMiddleware.cs
app.UseMiddleware<ExceptionMiddleware>();




app.UseHttpsRedirection();

app.UseAuthorization();

app.UseKissLogConfig(configuration);

app.MapControllers();

app.UseHealthChecks("/api/hc", new HealthCheckOptions
{
    Predicate = p => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options =>
{
    options.UIPath = "/Dashboard";
});

app.Run();
