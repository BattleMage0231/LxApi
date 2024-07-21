using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LxApi.Models;

public enum ClassFR {
    Noun, Verb, Adjective, Adverb, Preposition, Pronoun
}

public class EntryFR {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
    public ClassFR Class { get; set; }

    public string Key { get; set; } = null!;

    public string Definition { get; set; } = null!;

    public List<string> Examples { get; set; } = null!;
}
