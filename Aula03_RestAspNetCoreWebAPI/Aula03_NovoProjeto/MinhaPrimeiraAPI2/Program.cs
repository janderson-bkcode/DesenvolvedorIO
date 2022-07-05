using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinhaPrimeiraAPI2.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
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

//Configuração do DBContext e SQl 
builder.Services.AddDbContext<APIDbContext>(optionsAction: options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
