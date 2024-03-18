using System.Text.Json.Serialization;

namespace SerializationThings
{
    class EmployeeDecoratedSerialisable : Person
    {
        // CS8618: Non-nullable property 'Name' is uninitialized warning is here because the C#
        // wants to make sure we write good code. This is an example class and we know we can
        // ignore the property this warning. You could suppress it with #pragma warning disable CS8618
        public EmployeeDecoratedSerialisable(string name, int age)
        {
            Name = name;
            Age = age;
        }


        [JsonConstructor]
        public EmployeeDecoratedSerialisable(string name, int age, string jobTitle)
        {
            Name = name;
            Age = age;
            JobTitle = jobTitle;
        }

        // This property is not required so it can be omitted from the JSON or cased differently
        public string JobTitle { get; set; }
    }
}
