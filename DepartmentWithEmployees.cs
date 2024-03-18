using System.Text.Json.Serialization;

namespace SerializationThings
{
    internal class DepartmentWithEmployees
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }


    internal class DepartmentWithEmployees2
    {
        public string DepartmentName { get; set; }
        public List<Employee2> Employees { get; set; }
    }

    class Employee2 : Person
    {
        [JsonPropertyName("name")]
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [JsonPropertyName("age")]
        public new int Age
        {
            get { return base.Age; }
            set { base.Age = value; }
        }

        [JsonPropertyName("jobTitle")]
        public string JobTitle { get; set; }
    }


    internal class DepartmentWithEmployees3
    {
        public string DepartmentName { get; set; }
        public List<Employee3> Employees { get; set; }
    }
    class Employee3 : Person
    {
        [JsonPropertyName("name")]
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [JsonPropertyName("age")]
        public new int Age
        {
            get { return base.Age; }
            set { base.Age = value; }
        }

        [JsonPropertyName("jobTitle")]
        public string JobTitle { get; set; }

        [JsonPropertyName("otherProperties")]
        public Dictionary<string, object> OtherProperties { get; set; }
    }
}
