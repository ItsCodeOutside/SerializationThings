using System.Text.Json;

namespace SerializationThings.NameCasing
{
    internal class NameCasingExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- Name Casing Example ----");
            Console.WriteLine("In this example we have the following JSON:");
            Console.WriteLine();
            Console.WriteLine("{");
            Console.WriteLine("    \"name\": \"Steve\",");
            Console.WriteLine("    \"age\": 30");
            Console.WriteLine("}");
            Console.WriteLine();

            // Step 1 - Deserialise from JSON
            Console.WriteLine("We will deserialise the JSON to a C# object with 'required' properties.");
            var json = "{\"name\": \"Steve\", \"age\": 30}";
            try
            {
                var failDeserialization = JsonSerializer.Deserialize<PersonRequired>(json);
            }
            catch (JsonException ex)
            {
                /*
                JSON deserialization for type 'SerializationThings.PersonRequired' was missing required properties, including the following: Name, Age
                ... */

                Console.WriteLine("We get a JsonException because the properties on the PersonRequired class are cased differently" +
                    " to our JSON. Here is what the exception looks like");
                Console.WriteLine();
                Console.WriteLine($"\t{ex.GetType().Name}:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            // Step 2 - Fix the JSON
            Console.WriteLine("We have to match the property names in our JSON to the object we want to deserialise as.");
            json = "{\"Name\": \"Steve\", \"Age\": 30}";
            Console.WriteLine($"\t{json}");
            var successfulDeserialization = JsonSerializer.Deserialize<PersonRequired>(json);
            Console.WriteLine("We have successfully deserialised the JSON to a C# object.");
            Console.WriteLine($"PersonRequired: Name=\"{successfulDeserialization!.Name}\", Age={successfulDeserialization!.Age}");
            Console.WriteLine();

            // Step 3 - Conclusion
            Console.WriteLine("---- Name Casing Example Conclusion ----");
            Console.WriteLine("We have seen that the casing of property names in the JSON must match the casing of the" +
                " properties in the C# class when we use the 'required' keyword.");
        }
    }
}