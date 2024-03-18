using System.Text.Json.Serialization;

namespace SerializationThings
{
    class EmployeeDecoratedDifferentNamesWithoutConstructor : Person
    {
        // This attribute tells the deserialiser to look for a different property name in the JSON
        [JsonPropertyName("jobTitle")]
        public string PositionTitle { get; set; }
    }
}
