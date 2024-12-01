using WMSAPI.Constant;
using WMSAPI.Context;
using WMSAPI.Models;
using WMSAPI.Services;
using WMSAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWms,WmsUtilService>();
builder.Services.AddTransient<IOMS,OmsUtilService>();
builder.Services.AddTransient<ISpd,SpdUtilService>();
builder.Services.AddScoped<DBOMSConnect>();
builder.Services.AddScoped<DBWMSConnect>();
builder.Services.AddScoped<DBSPDConnect>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => 
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WMS API");
        opt.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
