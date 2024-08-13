using LxApi.Controllers;
using MongoDB.Bson.Serialization.Attributes;

namespace LxApi.Models.Languages;

public enum FRGender {
    Masculine, Feminine
}

public enum FRNumber {
    Singular, Plural
}

[BsonKnownTypes(typeof(FRNounEntry), typeof(FRVerbEntry), typeof(FRAdjectiveEntry), typeof(FRAdverbEntry), typeof(FRPrepositionEntry), typeof(FRArticleEntry), typeof(FRConjunctionEntry), typeof(FRPronounEntry), typeof(FROtherEntry))]
[Polymorphic(nameof(Class))]
[DerivedType(typeof(FRNounEntry), nameof(Class.Noun))]
[DerivedType(typeof(FRVerbEntry), nameof(Class.Verb))]
[DerivedType(typeof(FRAdjectiveEntry), nameof(Class.Adjective))]
[DerivedType(typeof(FRPrepositionEntry), nameof(Class.Preposition))]
[DerivedType(typeof(FRArticleEntry), nameof(Class.Article))]
[DerivedType(typeof(FRConjunctionEntry), nameof(Class.Conjunction))]
[DerivedType(typeof(FRPronounEntry), nameof(Class.Pronoun))]
[DerivedType(typeof(FROtherEntry), nameof(Class.Other))]
public abstract class FREntry : BaseEntry {}
