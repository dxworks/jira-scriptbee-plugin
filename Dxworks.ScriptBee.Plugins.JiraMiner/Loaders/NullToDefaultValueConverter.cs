using System;
using Newtonsoft.Json;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Loaders;

public class NullToDefaultValueConverter<TType> : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return default(TType);
        }

        return serializer.Deserialize(reader);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TType);
    }
}
