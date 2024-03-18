using System.Text.Json;

namespace SerializationThings.ConstructorParameters
{
    internal class ConstructorParametersExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- Constructor Parameters Example ----");
            Console.WriteLine("In this example we have a class with a constructor:");
            Console.WriteLine();
            Console.WriteLine("class Employee : Person");
            Console.WriteLine("{");
            Console.WriteLine("    public Employee(string name, int age, string jobTitle)");
            Console.WriteLine("    {");
            Console.WriteLine("        Name = name;");
            Console.WriteLine("        Age = age;");
            Console.WriteLine("        JobTitle = jobTitle;");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    public required string JobTitle { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("Let's recap what we know:");
            Console.WriteLine("\t- 'required' properties need exact casing");
            Console.WriteLine("\t- the Person class has no constructor");
            Console.WriteLine("\t- the Person has two non-required properties (Name, Age)");
            Console.WriteLine();

            // Step 1 - Deserialise invalid object from JSON
            var json = "{ \"name\": \"Steve\", \"age\": 30 }";
            Console.WriteLine("Here is a JSON object of the Person class. Let's try to deserialise" +
                " it to an Employee object.");
            Console.WriteLine($"\t{json}");
            try
            {
                var failDeserialization = JsonSerializer.Deserialize<Employee>(json);
            }
            catch (JsonException ex)
            {
                /*
                JSON deserialization for type 'SerializationThings.Employee' was missing required properties, including the following: JobTitle
                ... */
                Console.WriteLine("We get a JsonException because the constructor is expecting a 'jobTitle' property");
                Console.WriteLine();
                Console.WriteLine($"\t{ex.GetType().Name}:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            // Step 2 - Amend JSON and try to deserialise
            json = "{ \"name\": \"Steve\", \"age\": 30, \"jobTitle\": \"C# Developer\" }";
            Console.WriteLine("Here is our JSON with the 'jobTitle' property. It now matches the Employee constuctor but not the required property");
            Console.WriteLine($"\t{json}");
            try
            {
                var secondFailDeserialization = JsonSerializer.Deserialize<Employee>(json);
            }
            catch (JsonException ex)
            {
                /*
                JSON deserialization for type 'SerializationThings.Employee' was missing required properties, including the following: JobTitle
                ... */
                Console.WriteLine("We get a JsonException because the JobTitle property is required and the deserialiser" +
                    " is looking for exact case matches of properties in the JSON object to the C# class. It does not" +
                    " realise that the jobTitle constructor parameter is used to set that property.");
                Console.WriteLine();
                Console.WriteLine($"\t{ex.GetType().Name}:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            // Step 3 - Conclusion
            Console.WriteLine("---- Constructor Parameters Example Conclusion ----");
            Console.WriteLine("Any 'required' C# property must have an exactly case-matching property in" +
                "JSON for deserialization to work properly.");
        }
    }
}
