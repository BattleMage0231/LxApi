using LxApi.Models.Languages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LxApi.Models;

public enum Class {
    Noun, Verb, Adjective, Adverb, Preposition, Article, Conjunction, Pronoun, Other
}

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(FREntry))]
public abstract class BaseEntry {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public Class Class { get; set; }

    public string Key { get; set; } = null!;

    public string? Definition { get; set; }

    public string? Notes { get; set; }

    public List<string> Examples { get; set; } = [];

    public List<string> Synonyms { get; set; } = [];

    public List<BaseForm> OtherForms { get; set; } = [];
}
