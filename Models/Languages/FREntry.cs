using LxApi.Controllers;
using MongoDB.Bson.Serialization.Attributes;

namespace LxApi.Models.Languages;

public enum FRGender {
    Masculine, Feminine
}

public enum FRNumber {
    Singular, Plural
}

[BsonKnownTypes(typeof(FRNounEntry), typeof(FRVerbEntry))]
[Polymorphic(nameof(Class))]
[DerivedType(typeof(FRNounEntry), nameof(Class.Noun))]
[DerivedType(typeof(FRVerbEntry), nameof(Class.Verb))]
public abstract class FREntry : BaseEntry {}
