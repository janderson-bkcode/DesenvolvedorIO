using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinhaPrimeiraAPI2.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configurando documenta��o do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api Fornecedores",
        Description = "Api para Fornecedores",
        Contact = new OpenApiContact
        {
            Name = "SelfPay",
            Email = String.Empty,
            Url = new Uri("https://selfpay.com.br/"),
        }

    });

});


builder.Services.AddMvc();
builder.Services.AddMvcCore();
builder.Services.AddApiVersioning(options =>
{
    //Assume a vers�o default quando n�o for especificado
    options.AssumeDefaultVersionWhenUnspecified = true;
    //Definindo maior e menor vers�o
    options.DefaultApiVersion = new ApiVersion(majorVersion: 2, minorVersion: 0);
    //Quando consumir ele passar no header do response se est� obsoleta ou vers�o atual
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v',VVV";
    options.SubstituteApiVersionInUrl = true;
});

//Configura��o do DBContext e SQl 
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



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
