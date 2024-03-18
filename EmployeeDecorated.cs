using System.Text.Json.Serialization;

namespace SerializationThings
{
    class EmployeeDecorated : Person
    {
        [JsonConstructor]
        public EmployeeDecorated(string name, int age, string jobTitle)
        {
            Name = name;
            Age = age;
            JobTitle = jobTitle;
        }

        // This property is required so it must be present and cased correctly in JSON
        public required string JobTitle { get; set; }
    }
}
