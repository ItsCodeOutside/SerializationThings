namespace SerializationThings
{
    class Employee : Person
    {
        public Employee(string name, int age, string jobTitle)
        {
            Name = name;
            Age = age;
            JobTitle = jobTitle;
        }

        // The required keyword means this property must be set during object initialisation.
        // Setting it in the constructor is not enough for JSON deserialization or normal object intsantiation.
        public required string JobTitle { get; set; }
    }
}
