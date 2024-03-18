using System.Text.Json;

namespace SerializationThings.ConstructorParameterOrder
{
    internal class ConstructorParameterOrderExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- Constructor Parameter Order Example ----");
            Console.WriteLine("This example shows that the order of properties in JSON does not matter.");
            Console.WriteLine();
            Console.WriteLine("We will use the EmployeeDecorated class again. This is based on Person and" +
                " has one additional property, JobTitle, that is required.");

            // Step 1 - Deserialise object from JSON
            var json = "{\"JobTitle\":\"C# Developer\",\"Age\":30,\"Name\":\"John\"}";
            Console.WriteLine("Here is our JSON:");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            var deserialised = JsonSerializer.Deserialize<EmployeeDecorated>(json);
            Console.WriteLine($"EmployeeDecorated: Name=\"{deserialised!.Name}\", Age={deserialised!.Age}, JobTitle=\"{deserialised!.JobTitle}\"");
            Console.WriteLine();

            // Step 2 - Conclusion
            Console.WriteLine("---- Constructor Parameter Order Example Conclusion ----");
            Console.WriteLine("Parameter and property ordering is irrelevant but name casing is critical.");
            Console.WriteLine();
        }
    }
}
