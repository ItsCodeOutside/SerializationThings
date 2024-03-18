using System.Text.Json.Serialization;

namespace SerializationThings
{
    class EmployeeDecoratedDifferentNamesWithHiddenBaseProperty : Person
    {
        [JsonPropertyName("name")]
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }


        // This attribute tells the deserialiser to look for a different property name in the JSON
        [JsonPropertyName("jobTitle")]
        public string PositionTitle { get; set; }
    }
}
