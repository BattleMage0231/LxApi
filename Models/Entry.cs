using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LxApi.Models;

public enum Language {
    FR
}

public enum Class {
    Noun, Verb, Adjective, Adverb, Preposition, Pronoun
}

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(EntryFR))]
public class Entry {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public Language Language { get; set; }

    public Class Class { get; set; }

    public string Key { get; set; } = null!;

    public string Definition { get; set; } = null!;

    public List<string> Examples { get; set; } = null!;
}
