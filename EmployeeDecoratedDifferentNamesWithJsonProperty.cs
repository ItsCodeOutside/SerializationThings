using System.Text.Json.Serialization;

namespace SerializationThings
{
    class EmployeeDecoratedDifferentNamesWithJsonProperty : Person
    {

        [JsonConstructor]
        public EmployeeDecoratedDifferentNamesWithJsonProperty(string name, int age, string jobTitle)
        {
            Name = name;
            Age = age;
            PositionTitle = jobTitle;
        }

        // This attribute tells the deserialiser to look for a different property name in the JSON
        [JsonPropertyName("jobTitle")]
        public string PositionTitle { get; set; }
    }
}
