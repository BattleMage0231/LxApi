using LxApi.Models;
using LxApi.Services;
using LxApi.Controllers;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

var pack = new ConventionPack {
    new EnumRepresentationConvention(BsonType.String)
};
ConventionRegistry.Register("EnumStringConvention", pack, t => true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<JsonOptions>(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IMongoService, MongoService>();
builder.Services.AddSingleton<IEntriesFRService, EntriesFRService>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();
