using LxApi.Models.Languages;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LxApi.Models;

public enum Class {
    Noun, Verb, Adjective, Adverb, Preposition, Pronoun
}

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(FREntry))]
public abstract class Entry {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public Class Class { get; set; }

    public string Key { get; set; } = null!;

    public string? Definition { get; set; }

    public List<string> Examples { get; set; } = [];

    public List<string> Synonyms { get; set; } = [];
}
