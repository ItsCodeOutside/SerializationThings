using System.Text.Json;

namespace SerializationThings.BasicRequired
{
    internal class BasicRequiredExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- Basic Required Example ----");
            Console.WriteLine("In this example we have a class with 'required' properties:");
            Console.WriteLine();
            Console.WriteLine("class PersonRequired");
            Console.WriteLine("{");
            Console.WriteLine("    public required string Name { get; set; }");
            Console.WriteLine("    public required int Age { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();

            // Step 1 - Create object
            Console.WriteLine("We will create an instance of this class and serialise it to JSON.");
            var personRequired = new PersonRequired { Name = "Steve", Age = 30 };
            Console.WriteLine("Here is our C# object:");
            Console.WriteLine($"\tPersonRequired: Name=\"{personRequired.Name}\", Age={personRequired.Age}");

            // Step 2 - Serialise to JSON
            var json = JsonSerializer.Serialize(personRequired);
            Console.WriteLine("Here is the JSON:");
            Console.WriteLine($"\t{json}");
            Console.WriteLine("Notice that the properties are cased the same as the C# class. This is different" +
                " to the behaviour shown Basic example where the properties are lowercase by default.");

            // Step 3 - Deserialise from JSON
            Console.WriteLine("We will now deserialise the JSON back to a C# object.");
            var deserialisedPersonRequired = JsonSerializer.Deserialize<PersonRequired>(json);
            Console.WriteLine("Here is our C# object:");
            Console.WriteLine($"\tPersonRequired: Name=\"{deserialisedPersonRequired!.Name}\", Age={deserialisedPersonRequired!.Age}");
            Console.WriteLine();

            // Step 4 - Conclusion
            Console.WriteLine("---- Basic Required Example Conclusion ----");
            Console.WriteLine("We have initialised, serialised, and deserialised a basic C# object with 'required'" +
                " properties and saw that this changes the serialization behaviour for casing property names.");
        }
    }
}
