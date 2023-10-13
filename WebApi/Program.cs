using Application;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
     
    c.SwaggerDoc("v1", new OpenApiInfo
      {
          Title = "CineFlex Docs Api",
          Version = "v1",
          TermsOfService = new Uri("https://johnson.com/"),
          Contact = new OpenApiContact
          {
              Name = "Dawodu Johnson",
              Email = "dawodu.johnson@a2sv.org",
              Url = new Uri("https://lol.com")
          },
          License = new OpenApiLicense
          {
              Name = "MIT",
              Url = new Uri("http://mit.org")
          }
      });
  }
);

builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    policy.AllowAnyMethod().
    AllowCredentials().
    AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CineFlex Docs Api v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("CorsPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
