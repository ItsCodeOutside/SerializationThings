using System.Text.Json;

namespace SerializationThings.ComplexObjectWithCorrectCasing
{
    internal class ComplexObjectWithCorrectCasingExample
    {
        public void Run()
        {
            // Introduction
            Console.WriteLine("In this example, we will create a more complicated object.");
            Console.WriteLine();
            Console.WriteLine("internal class DepartmentWithEmployees");
            Console.WriteLine("{");
            Console.WriteLine("    public string DepartmentName { get; set; }");
            Console.WriteLine("    public List<Employee> Employees { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine();

            var complexObject = new DepartmentWithEmployees
            {
                DepartmentName = "Product Team",

                /* NOTE: Both jobTitle and JobTitle are specified because the JobTitle property is 'required' in the Employee class.
                   To avoid confusion in your code, do not use the 'required' keyword on properties you will set in the constructor.

                   A simple rule to follow is to use the 'required' keyword if both of these are true:
                    1. You do not have a constructor on your class
                    2. You want to enforce that the property is set when the object is created.
                */
                Employees = new List<Employee>
                {
                    new Employee(
                        name: "Steve",
                        age: 30,
                        jobTitle: "C# Developer"
                    )
                    {
                        JobTitle = "C# Developer"
                    },
                    new Employee(
                        name: "Sandra",
                        age: 30,
                        jobTitle: "Manager")
                    {
                        JobTitle = "Manager"
                    }
                }
            };

            // Step 1 - Serialise the object
            var json = JsonSerializer.Serialize(complexObject);
            Console.WriteLine("Here is our JSON:");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();

            Console.WriteLine("We can easily deserialise the object because all properties exist and are correctly cased.");
            var deserialised = JsonSerializer.Deserialize<DepartmentWithEmployees>(json);
            Console.WriteLine($"Department Name: {deserialised!.DepartmentName}");
            Console.WriteLine($"Employee 1: {deserialised.Employees[0].Name} - {deserialised.Employees[0].JobTitle}");
            Console.WriteLine($"Employee 2: {deserialised.Employees[1].Name} - {deserialised.Employees[1].JobTitle}");
            Console.WriteLine();

            // Step 2 - Deserialising an object that has different casing
            json = "{\"departmentName\":\"Product Team\",\"Employees\":[{\"JobTitle\":\"C# Developer\",\"Name\":\"Steve\",\"Age\":30},{\"JobTitle\":\"Manager\",\"Name\":\"Sandra\",\"Age\":30}]}";
            Console.WriteLine("Here is our JSON with different casing:");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            var successfullyDeserialised = JsonSerializer.Deserialize<DepartmentWithEmployees>(json);
            Console.WriteLine("Deserialise seems to work but the differently-cased property, DepartmentName, is silently ignored so it gets its default value of null.");
            Console.WriteLine($"Department Name: {successfullyDeserialised!.DepartmentName}");
            Console.WriteLine($"Employee 1: {successfullyDeserialised.Employees[0].Name} - {successfullyDeserialised.Employees[0].JobTitle}");
            Console.WriteLine($"Employee 2: {successfullyDeserialised.Employees[1].Name} - {successfullyDeserialised.Employees[1].JobTitle}");
            Console.WriteLine();

            // Step 3 - Failed deserialization of Employee list
            json = "{\"DepartmentName\":\"Product Team\",\"Employees\":[{\"jobTitle\":\"C# Developer\",\"Name\":\"Steve\",\"age\":30},{\"jobTitle\":\"Manager\",\"name\":\"Sandra\",\"age\":30}]}";
            Console.WriteLine("Here is our JSON with different casing in the Employee list:");
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            Console.WriteLine("We know that the non-matching property names will be ignored and receive their default value when deserialised to the DepartmentWithEmployees class" +
                " and that the required property, JobTitle, will cause an exception because the casing has been changed in the JSON." +
                " Instead, let's try to deserialise to the DepartmentWithEmployees2 class which uses List<Employee2> that does not have a required property and makes use of the JsonPropertyName attribute.");
            Console.WriteLine();
            var successfullyDeserialised2 = JsonSerializer.Deserialize<DepartmentWithEmployees2>(json);
            Console.WriteLine($"Department Name: {successfullyDeserialised2!.DepartmentName}");
            Console.WriteLine($"Employee 1: {successfullyDeserialised2.Employees[0].Name} - {successfullyDeserialised2.Employees[0].JobTitle}");
            Console.WriteLine($"Employee 2: {successfullyDeserialised2.Employees[1].Name} - {successfullyDeserialised2.Employees[1].JobTitle}");
            Console.WriteLine();

            // Step 4 - Deserialising an object with a dictionary
            Console.WriteLine("As long as your casing is correct by using either JsonPropertyName or simply the matching the name exactly in your C# class to the JSON, you can successfully serialise almost any object." +
                " Here is an example using DepartmentWithEmployees3 with a a List<Employee3> that has a Dictionary<string, object> property:");
            Console.WriteLine();
            json = "{\"DepartmentName\":\"Product Team\",\"Employees\":[{\"name\":\"Steve\",\"age\":30,\"jobTitle\":\"C# Developer\",\"otherProperties\":{\"Pet's Name\": \"Mittens\", \"hobbies\":[\"cycling\",\"running\"]}},{\"name\":\"Sandra\",\"age\":30,\"jobTitle\":\"Manager\",\"otherProperties\":{\"Car Manufacturer\": \"Aston Martin\",\"hobbies\":[\"swimming\",\"reading\"]}}]}";
            Console.WriteLine($"\t{json}");
            Console.WriteLine();
            Console.WriteLine("Let's deserialise the object:");
            var successfullyDeserialised3 = JsonSerializer.Deserialize<DepartmentWithEmployees3>(json);
            Console.WriteLine($"Department Name: {successfullyDeserialised3!.DepartmentName}");
            Console.WriteLine($"Employee 1: {successfullyDeserialised3.Employees[0].Name} - {successfullyDeserialised3.Employees[0].JobTitle}");
            foreach(var property in successfullyDeserialised3.Employees[0].OtherProperties)
            {
                Console.WriteLine($"\t{property.Key}: {property.Value}");
            }
            Console.WriteLine($"Employee 2: {successfullyDeserialised3.Employees[1].Name} - {successfullyDeserialised3.Employees[1].JobTitle}");
            foreach (var property in successfullyDeserialised3.Employees[1].OtherProperties)
            {
                Console.WriteLine($"\t{property.Key}: {property.Value}");
            }
            Console.WriteLine();
        }
    }
}
