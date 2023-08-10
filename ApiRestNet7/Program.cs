//Referencias a utilizar
using Microsoft.EntityFrameworkCore;
using ApiRestNet7.Models;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//Conexion con la base de datos
builder.Services.AddDbContext<DbAngularContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });
});


var app = builder.Build();

/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
