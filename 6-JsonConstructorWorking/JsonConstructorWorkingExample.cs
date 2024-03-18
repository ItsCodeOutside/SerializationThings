using System.Text.Json;

namespace SerializationThings.JsonConstructorWorking
{
    internal class JsonConstructorWorkingExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- JSON Constructor Working Example ----");
            Console.WriteLine("In this example we have a class with two constructors. One is decorated with 'JsonConstructor'" +
                " and the other is not. We also have a differently-named non-required property" +
                " that is handled differently in the decorated constructor.");
            Console.WriteLine();
            Console.WriteLine("class EmployeeDecoratedSerialisable : Person");
            Console.WriteLine("{");
            Console.WriteLine("    public EmployeeDecoratedSerialisable(string name, int age)");
            Console.WriteLine("    {");
            Console.WriteLine("        Name = name;");
            Console.WriteLine("        Age = age;");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    [JsonConstructor]");
            Console.WriteLine("    public EmployeeDecoratedSerialisable(string name, int age, string jobTitle)");
            Console.WriteLine("    {");
            Console.WriteLine("        Name = name;");
            Console.WriteLine("        Age = age;");
            Console.WriteLine("        JobTitle = jobTitle;");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    public string JobTitle { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("Notice that the first constructor does not set PositionTitle while" +
                " the second expects a 'jobTitle' parameter and uses that to set the non-required property.");

            // Step 1 - Fail to deserialise object from JSON but generate no error
            var json = "{\"name\":\"Steve\",\"age\":30,\"jobTitle\":\"C# Developer\"}";
            Console.WriteLine("Here is our JSON with the 'jobTitle' property. It now matches the EmployeeDecoratedSerialisable" +
                " constuctor but not the required property");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            Console.WriteLine("Important! See that the JSON property names match the casing in the constructor...");
            Console.WriteLine();
            var deserialised = JsonSerializer.Deserialize<EmployeeDecoratedSerialisable>(json);
            Console.WriteLine($"EmployeeDecoratedSerialisable: Name=\"{deserialised!.Name}\", Age={deserialised!.Age}, JobTitle=\"{deserialised!.JobTitle}\"");
            Console.WriteLine();
            Console.WriteLine("... and that we do not get our values or an error to tell us something went wrong.");
            Console.WriteLine("Even though we're specifying which constructor to use and matching the property" +
                " names correctly, the deserialiser silently ignores them");
            Console.WriteLine();

            // Step 2 - Fixing the JSON
            json = "{\"Name\":\"Steve\",\"Age\":30,\"JobTitle\":\"C# Developer\"}";
            Console.WriteLine("Here is our JSON with the property casing that matches the C# properties," +
                " NOT the constructor parameters.");
            Console.WriteLine();
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            var deserialisedFixed = JsonSerializer.Deserialize<EmployeeDecoratedSerialisable>(json);
            Console.WriteLine();
            Console.WriteLine("Here is our deserialised object.");
            Console.WriteLine($"EmployeeDecoratedSerialisable: Name=\"{deserialisedFixed!.Name}\", Age={deserialisedFixed!.Age}, JobTitle=\"{deserialisedFixed!.JobTitle}\"");
            Console.WriteLine();

            // Step 3 - Omitting a non-required property
            json = "{\"Name\":\"Steve\",\"Age\":30}";
            Console.WriteLine("Here is JSON with a missing property, let's deserialise it.");
            Console.WriteLine();
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            var deserialisedOmitted = JsonSerializer.Deserialize<EmployeeDecoratedSerialisable>(json);
            Console.WriteLine();
            Console.WriteLine("Here is our deserialised object.");
            Console.WriteLine($"EmployeeDecoratedSerialisable: Name=\"{deserialisedOmitted!.Name}\", Age={deserialisedOmitted!.Age}, JobTitle=\"{deserialisedOmitted!.JobTitle}\"");
            Console.WriteLine();
            Console.WriteLine("The jobTitle property was not found in JSON so it receives the default value for its type.");
            Console.WriteLine();

            // Step 4 - Unused properties
            json = "{\"Name\":\"Steve\",\"Age\":30,\"Pay\":100}";
            Console.WriteLine("Here is JSON with an extra property, let's deserialise it.");
            Console.WriteLine();
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            var deserialisedExtra = JsonSerializer.Deserialize<EmployeeDecoratedSerialisable>(json);
            Console.WriteLine();
            Console.WriteLine("Here is our deserialised object.");
            Console.WriteLine($"EmployeeDecoratedSerialisable: Name=\"{deserialisedExtra!.Name}\", Age={deserialisedExtra!.Age}, JobTitle=\"{deserialisedExtra!.JobTitle}\"");
            Console.WriteLine();
            Console.WriteLine("In this example the extra property is ignored and the constructor's jobTitle parameter " +
                "receives the default value for its type because it was omitted");
            Console.WriteLine();

            // Step 4 - Conclusion
            Console.WriteLine("---- JSON Constructor Working Example Conclusion ----");
            Console.WriteLine("If a constructor is specified, deserialization becomes case-sensitive even though the parameters" +
                " on the constructor are not");
        }
    }
}
