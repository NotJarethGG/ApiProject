using Dta.Data;
using Microsoft.EntityFrameworkCore;
using Dta;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDta(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().WithMethods().WithHeaders();
                      });
});


//Para SQL server
builder.Services.AddDbContext<ApiProjectBolsaEmpleo_Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ApiProjectBolsaEmpleo_Context") ?? throw new InvalidOperationException("Connection string 'ApiProjectBolsaEmpleo_Context' not found.")));

//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
    