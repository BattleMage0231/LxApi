using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using System.Collections.ObjectModel;

namespace LxApi.Controllers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
public class PolymorphicAttribute(string propName) : Attribute {
    public string TypeDiscriminatorPropertyName { get; } = propName;
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
public class DerivedTypeAttribute(Type type, string discrim) : Attribute {
    public Type DerivedType { get; } = type;

    public string TypeDiscriminator { get; } = discrim;
}

public class PolymorphicJsonConverter<T> : JsonConverter<T> {
    private static readonly string DiscriminatorName;

    private static readonly ReadOnlyDictionary<string, Type> DiscriminatorToSubtypeMap;

    private static readonly ReadOnlyDictionary<Type, string> SubtypeToDiscriminatorMap;

    static PolymorphicJsonConverter() {
        var polymorphicAttribute = typeof(T).GetCustomAttribute<PolymorphicAttribute>();
        var derivedTypeAttributes = typeof(T).GetCustomAttributes<DerivedTypeAttribute>().ToList();
        DiscriminatorName = (polymorphicAttribute?.TypeDiscriminatorPropertyName) ?? "$type";
        var discrimDict = new Dictionary<string, Type>();
        var subtypeDict = new Dictionary<Type, string>();
        foreach(var derivedType in derivedTypeAttributes) {
            if(!typeof(T).IsAssignableFrom(derivedType.DerivedType)) {
                throw new ArgumentException($"Type {derivedType.DerivedType} is not assignable from {typeof(T)}");
            }
            discrimDict.Add(derivedType.TypeDiscriminator, derivedType.DerivedType);
            subtypeDict.Add(derivedType.DerivedType, derivedType.TypeDiscriminator);
        }
        DiscriminatorToSubtypeMap = new ReadOnlyDictionary<string, Type>(discrimDict);
        SubtypeToDiscriminatorMap = new ReadOnlyDictionary<Type, string>(subtypeDict);
    }

    public override bool CanConvert(Type type) => typeof(T).IsAssignableFrom(type);

    private JsonSerializerOptions GetBaseOptions(JsonSerializerOptions options) {
        var newOptions = new JsonSerializerOptions(options);
        newOptions.Converters.Remove(this);
        return newOptions;
    }

    public override T? Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions options) {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var discrimField = root.GetProperty(DiscriminatorName);
        if(discrimField.GetString() is not string typeName) {
            throw new JsonException($"Could not find string property {DiscriminatorName}");
        }
        if(!DiscriminatorToSubtypeMap.TryGetValue(typeName, out Type? type)) {
            throw new JsonException($"Unknown type {type}");
        }
        return (T?) doc.Deserialize(type, GetBaseOptions(options));
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
        var type = value!.GetType();
        writer.WriteStartObject();
        writer.WriteString(DiscriminatorName, SubtypeToDiscriminatorMap.GetValueOrDefault(type));
        using var doc = JsonSerializer.SerializeToDocument(value, type, GetBaseOptions(options));
        foreach(var prop in doc.RootElement.EnumerateObject()) {
            writer.WritePropertyName(prop.Name);
            prop.Value.WriteTo(writer);
        }
        writer.WriteEndObject();
    }
}
