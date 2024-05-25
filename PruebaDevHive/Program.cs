using Microsoft.EntityFrameworkCore;
using PruebaDevHive.Models;
using PruebaDevHive.Repository;
using PruebaDevHive.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
                      });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//mio
builder.Services.AddDbContext<InmueblesDevHiveContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DHConnection"));
});

builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

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

//cors
app.UseCors(MyAllowSpecificOrigins);

app.Run();
