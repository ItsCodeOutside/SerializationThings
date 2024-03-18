using System.Text.Json.Serialization;

namespace SerializationThings
{
    class EmployeeDecoratedDifferentNames : Person
    {
        [JsonConstructor]
        public EmployeeDecoratedDifferentNames(string name, int age, string jobTitle)
        {
            Name = name;
            Age = age;
            PositionTitle = jobTitle;
        }

        // This property has a different name to the expected parameter on the constructor
        public string PositionTitle { get; set; }
    }
}
