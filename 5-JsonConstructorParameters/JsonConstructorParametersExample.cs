using System.Text.Json;

namespace SerializationThings.JsonConstructorParameters
{
    internal class JsonConstructorParametersExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- JSON Constructor Parameters Example ----");
            Console.WriteLine("In this example we have a class with a specially decorated 'JsonConstructor':");
            Console.WriteLine("class EmployeeDecorated : Person");
            Console.WriteLine("{");
            Console.WriteLine("    [JsonConstructor]");
            Console.WriteLine("    public EmployeeDecorated(string name, int age, string jobTitle)");
            Console.WriteLine("    {");
            Console.WriteLine("        Name = name;");
            Console.WriteLine("        Age = age;");
            Console.WriteLine("        JobTitle = jobTitle;");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    public required string JobTitle { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();

            var json = "{ \"name\": \"Steve\", \"age\": 30, \"jobTitle\": \"C# Developer\" }";
            Console.WriteLine("Here is our JSON with the 'jobTitle' property. It now matches the EmployeeDecorated" +
                " constuctor but not the required property");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();

            // Step 1 - Deserialise object from JSON
            try
            {
                var deserializationFailure = JsonSerializer.Deserialize<EmployeeDecorated>(json);
            }
            catch (JsonException ex)
            {
                /*
                JSON deserialization for type 'SerializationThings.EmployeeDecorated' was missing required properties, including the following: JobTitle
                ... */
                Console.WriteLine("We get a JsonException because the 'JobTitle' property is required, even though" +
                    " we used the JsonConstructor attribute.");
                Console.WriteLine();
                Console.WriteLine($"\t{ex.GetType().Name}:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            // Step 2 - Conclusion
            Console.WriteLine("---- JSON Constructor Parameters Example Conclusion ----");
            Console.WriteLine("The JsonConstructor attribute only specifies which constructor the deserialiser should use," +
                " it does not modify the behaviour of required properties during deserialization.");
            Console.WriteLine();
            Console.WriteLine("Any 'required' property must be present in the JSON in exactly the same casing.");
            Console.WriteLine();
        }
    }
}
