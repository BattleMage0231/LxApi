using LxApi.Models;
using LxApi.Models.Languages;
using LxApi.Services;
using LxApi.Controllers;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.Conventions;

var pack = new ConventionPack {
    new EnumRepresentationConvention(BsonType.String)
};
ConventionRegistry.Register("EnumStringConvention", pack, t => true);
BsonSerializer.RegisterSerializer(new EnumSerializer<FRGender>(BsonType.String));
BsonSerializer.RegisterSerializer(new EnumSerializer<FRNumber>(BsonType.String));
BsonSerializer.RegisterSerializer(new EnumSerializer<FRPerson>(BsonType.String));
BsonSerializer.RegisterSerializer(new EnumSerializer<FRVerbConjugationType>(BsonType.String));

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<JsonOptions>(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IMongoService, MongoService>();
builder.Services.AddSingleton(typeof(IEntriesService<>), typeof(EntriesService<>));
builder.Services.AddSingleton(typeof(ISearchService<>), typeof(SearchService<>));
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.Converters.Add(new PolymorphicJsonConverter<FREntry>());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowLocalhost",
	builder =>
	{
	    builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowLocalhost");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
