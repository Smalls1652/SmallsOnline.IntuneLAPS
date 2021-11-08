using System.Text.Json;

using SmallsOnline.IntuneLAPS.Lib.Models.JSON;

namespace SmallsOnline.IntuneLAPS.Lib.Helpers
{

    /// <summary>
    /// Hosts methods for serializing and deserializing JSON objects.
    /// </summary>
    public static class JsonConverterHelper
    {
        /// <summary>
        /// Convert a JSON string to a specified class object.
        /// </summary>
        /// <typeparam name="T">The specified type of the output class object.</typeparam>
        /// <param name="inputString">The string of the JSON to convert.</param>
        /// <returns></returns>
        public static T ConvertFromJson<T>(string inputString)
        {
            JsonSerializerOptions deserializationOptions = new();
            deserializationOptions.Converters.Add(new TimeSpanJsonConverter());
            
            T convertedItem = JsonSerializer.Deserialize<T>(inputString, deserializationOptions);

            return convertedItem;
        }

        /// <summary>
        /// Convert a class object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The specified type of the output class object.</typeparam>
        /// <param name="inputObject">The object to convert to a JSON string.</param>
        /// <returns></returns>
        public static string ConvertToJson<T>(T inputObject)
        {
            JsonSerializerOptions serializerOptions = new() {
                WriteIndented = true
            };
            serializerOptions.Converters.Add(new TimeSpanJsonConverter());
            
            string convertedItem = JsonSerializer.Serialize<T>(inputObject, serializerOptions);

            return convertedItem;
        }
    }
}