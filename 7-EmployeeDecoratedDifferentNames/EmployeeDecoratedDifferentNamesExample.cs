using System.Text.Json;

namespace SerializationThings.EmployeeDecoratedDifferentProperties
{
    internal class EmployeeDecoratedDifferentNamesExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("---- Employee Decorated Different Names Example ----");
            Console.WriteLine("This example shows a class with a different property name to what is expected from the Json");
            Console.WriteLine();
            Console.WriteLine("class EmployeeDecoratedDifferentNames : Person");
            Console.WriteLine("{");
            Console.WriteLine("    [JsonConstructor]");
            Console.WriteLine("    public EmployeeDecoratedDifferentNames(string name, int age, string jobTitle)");
            Console.WriteLine("    {");
            Console.WriteLine("        Name = name;");
            Console.WriteLine("        Age = age;");
            Console.WriteLine("        PositionTitle = jobTitle;");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    public string PositionTitle { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();

            // Step 1 - Fail to deserialise object from JSON
            var json = "{\"name\":\"John\",\"age\":30,\"jobTitle\":\"C# Developer\"}";
            Console.WriteLine("Here is our JSON, let's try to deserialise it");
            Console.WriteLine();
            Console.WriteLine(json);
            Console.WriteLine();
            try
            {
                var failDeserialised = JsonSerializer.Deserialize<EmployeeDecoratedDifferentNames>(json);
            }
            catch (Exception ex)
            {
                /*
                Each parameter in the deserialization constructor on type 'SerializationThings.EmployeeDecoratedDifferentNames' must bind to an object property or field on deserialization. Each parameter name must match with a property or field on the object. Fields are only considered when 'JsonSerializerOptions.IncludeFields' is enabled. The match can be case-insensitive.
                ... */
                Console.WriteLine("We get a InvalidOperationException because the deserializer is expecting the constructor's parameter" +
                    " names to match an existing property. The casing can be different but the name must match.");
                Console.WriteLine();
                Console.WriteLine($"\t{ex.GetType().Name}:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            // Step 2 - Fix the class with JsonPropertyName attribute
            Console.WriteLine("We can fix this by using the JsonPropertyName attribute to tell the deserializer to look for a different" +
                               " property name in the JSON");
            Console.WriteLine();
            Console.WriteLine("        [JsonPropertyName(\"jobTitle\")]");
            Console.WriteLine("    public string PositionTitle { get; set; }");
            Console.WriteLine();
            Console.WriteLine("Important! The jobTitle parameter no longer matches a property!");
            Console.WriteLine();

            // Step 3 - Deserialise object from JSON using class with JsonPropertyName attribute
            Console.WriteLine("Now let's try to deserialise the JSON again");
            Console.WriteLine();
            try
            {
                var secondFailDeserialised = JsonSerializer.Deserialize<EmployeeDecoratedDifferentNamesWithJsonProperty>(json);
            }
            catch (Exception ex)
            {
                /*
                Each parameter in the deserialization constructor on type 'SerializationThings.EmployeeDecoratedDifferentNamesWithJsonProperty' must bind to an object property or field on deserialization. Each parameter name must match with a property or field on the object. Fields are only considered when 'JsonSerializerOptions.IncludeFields' is enabled. The match can be case-insensitive.
                ... */
                Console.WriteLine("We get a InvalidOperationException because the deserializer now demands that the jobTitle parameter" +
                    " have a matching property. The casing of the property can be different but there be a property that matches each" +
                    " constructor parameter when using a constructor for deserialization. Even if the property is not" +
                    " expected to ever exist in the JSON.");
                Console.WriteLine();
                Console.WriteLine($"\t{ex.GetType().Name}:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            // Step 4 - Deserialise object from JSON using class without constructor
            Console.WriteLine("We can fix this by using a class without a constructor");
            Console.WriteLine();
            Console.WriteLine("class EmployeeDecoratedDifferentNamesWithoutConstructor : Person");
            Console.WriteLine("{");
            Console.WriteLine("    [JsonPropertyName(\"jobTitle\")]");
            Console.WriteLine("    public string PositionTitle { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Now let's try to deserialise the JSON again");
            Console.WriteLine();
            var successDeserialised = JsonSerializer.Deserialize<EmployeeDecoratedDifferentNamesWithoutConstructor>(json);
            Console.WriteLine();
            Console.WriteLine($"EmployeeDecoratedDifferentNamesWithoutConstructor: Name=\"{successDeserialised!.Name}\", Age={successDeserialised!.Age}, PositionTitle=\"{successDeserialised!.PositionTitle}\"");
            Console.WriteLine();
            Console.WriteLine("This time we successfully got the jobTitle/PositionTitle but Name and Age were silently ignored." +
                " This is because they are properties on the base class and the deserializer only checks for matching" +
                " case-insensitive property names in 'this' class.");
            Console.WriteLine();

            // Step 5 - Hiding base members
            Console.WriteLine("To set base member properties from a JSON that uses different casing" +
                " you can hide the base property with one that does match: ");

            Console.WriteLine("[JsonPropertyName(\"name\")]" +
                "public new string Name" +
                "{" +
                "    get { return base.Name; }" +
                "    set { base.Name = value; }" +
                "}");
            Console.WriteLine();
            Console.WriteLine("Here's the JSON we're using, et's deserialise the JSON again");
            Console.WriteLine();
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            var successDeserialisedWithHiddenBaseProperty = JsonSerializer.Deserialize<EmployeeDecoratedDifferentNamesWithHiddenBaseProperty>(json);
            Console.WriteLine();
            Console.WriteLine($"EmployeeDecoratedDifferentNamesWithHiddenBaseProperty: Name=\"{successDeserialisedWithHiddenBaseProperty!.Name}\", Age={successDeserialisedWithHiddenBaseProperty!.Age}, PositionTitle=\"{successDeserialisedWithHiddenBaseProperty!.PositionTitle}\"");
            Console.WriteLine();

            // Step 6 - Conclusion
            Console.WriteLine("---- Employee Decorated Different Names Example Conclusion ----");
            Console.WriteLine("If your JSON will have different names or even just different casing of" +
                " your classes property names, you must decorate your class and maybe hide base-class" +
                " members so that the deserializer can properly re-create your object.");
            Console.WriteLine();
        }
    }
}
