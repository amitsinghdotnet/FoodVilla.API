using FoodVilla.API.Data;
using FoodVilla.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<FoodVillaDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FoodVillaConnectionStrings")));
builder.Services.AddControllers(opt =>
{
    opt.RespectBrowserAcceptHeader = true;
}).AddXmlSerializerFormatters();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Food Villa"); });

app.Run();

