using System.Text.Json;

namespace SerializationThings.Basic
{
    internal class BasicExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- Basic Example ----");
            Console.WriteLine("In this example we have the following class:");
            Console.WriteLine();
            Console.WriteLine("class Person");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name { get; set; }");
            Console.WriteLine("    public int Age { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();

            // Step 1 - Create object
            Console.WriteLine("We will create an instance of this class and serialise it to JSON.");
            var person = new Person { Name = "Steve", Age = 30 };
            Console.WriteLine("Here is our C# object:");
            Console.WriteLine($"\tPerson: Name=\"{person.Name}\", Age={person.Age}");
            Console.WriteLine();

            // Step 2 - Serialise to JSON
            var json = JsonSerializer.Serialize(person);
            Console.WriteLine("Here is the JSON:");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();

            // Step 3 - Deserialise from JSON
            Console.WriteLine("We will now deserialise the JSON back to a C# object.");
            var deserialisedPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine("Here is our C# object:");
            Console.WriteLine($"\tPerson: Name=\"{deserialisedPerson!.Name}\", Age={deserialisedPerson!.Age}");
            Console.WriteLine("Now we have a deserialised Person with the same values as our first object, but " +
                "it is a different instance:");
            /*
             * The following line will output "person == deserialisedPerson: False"
             * This is because the deserialisedPerson is a different instance to the person object.
             * This is a common gotcha when working with serialization.
             */
            Console.WriteLine($"\tperson == deserialisedPerson: {person == deserialisedPerson}");
            Console.WriteLine();

            // Step 4 - Conclusion
            Console.WriteLine("---- Basic Example Conclusion ----");
            Console.WriteLine("We have initialised, serialised, and deserialised a basic C# object and noted" +
                "that the deserialised object is a different instance to the original object.");
        }
    }
}
