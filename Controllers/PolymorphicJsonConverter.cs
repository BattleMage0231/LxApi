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
    private static readonly string discriminatorName;

    private static readonly ReadOnlyDictionary<string, Type> discriminatorToSubtypeMap;

    private static readonly ReadOnlyDictionary<Type, string> subtypeToDiscriminatorMap;

    static PolymorphicJsonConverter() {
        var polymorphicAttribute = typeof(T).GetCustomAttribute<PolymorphicAttribute>();
        var derivedTypeAttributes = typeof(T).GetCustomAttributes<DerivedTypeAttribute>().ToList();
        discriminatorName = (polymorphicAttribute?.TypeDiscriminatorPropertyName) ?? "$type";
        var discrimDict = new Dictionary<string, Type>();
        var subtypeDict = new Dictionary<Type, string>();
        foreach(var derivedType in derivedTypeAttributes) {
            if(!typeof(T).IsAssignableFrom(derivedType.DerivedType)) {
                throw new ArgumentException($"Type {derivedType.DerivedType} is not assignable from {typeof(T)}");
            }
            discrimDict.Add(derivedType.TypeDiscriminator, derivedType.DerivedType);
            subtypeDict.Add(derivedType.DerivedType, derivedType.TypeDiscriminator);
        }
        discriminatorToSubtypeMap = new ReadOnlyDictionary<string, Type>(discrimDict);
        subtypeToDiscriminatorMap = new ReadOnlyDictionary<Type, string>(subtypeDict);
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
        var discrimField = root.GetProperty(discriminatorName);
        if(discrimField.GetString() is not string typeName) {
            throw new JsonException($"Could not find string property {discriminatorName}");
        }
        if(!discriminatorToSubtypeMap.TryGetValue(typeName, out Type? type)) {
            throw new JsonException($"Unknown type {type}");
        }
        return (T?) doc.Deserialize(type, GetBaseOptions(options));
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
        var type = value!.GetType();
        writer.WriteStartObject();
        writer.WriteString(discriminatorName, subtypeToDiscriminatorMap.GetValueOrDefault(type));
        using var doc = JsonSerializer.SerializeToDocument(value, type, GetBaseOptions(options));
        foreach(var prop in doc.RootElement.EnumerateObject()) {
            writer.WritePropertyName(prop.Name);
            prop.Value.WriteTo(writer);
        }
        writer.WriteEndObject();
    }
}
