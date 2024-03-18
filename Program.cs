using SerializationThings.Basic;
using SerializationThings.BasicRequired;
using SerializationThings.ComplexObjectWithCorrectCasing;
using SerializationThings.ConstructorParameterOrder;
using SerializationThings.ConstructorParameters;
using SerializationThings.EmployeeDecoratedDifferentProperties;
using SerializationThings.JsonConstructorParameters;
using SerializationThings.JsonConstructorWorking;
using SerializationThings.NameCasing;

namespace SerializationThings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeText();
            string input;
            while (true)
            {
                Console.WriteLine(); // Leave a gap between the previous output and the prompt
                WritePrompt();
                input = Console.ReadLine()!;
                switch (input.ToLower())
                {
                    case "quit":
                    case "exit":
                        return;

                    case "1":
                    case "basic":
                        new BasicExample().Run();
                        break;

                    case "2":
                    case "basicrequired":
                        new BasicRequiredExample().Run();
                        break;

                    case "3":
                    case "namecasing":
                        new NameCasingExample().Run();
                        break;

                    case "4":
                    case "constructorparameters":
                        new ConstructorParametersExample().Run();
                        break;

                    case "5":
                    case "jsonconstructorparameters":
                        new JsonConstructorParametersExample().Run();
                        break;

                    case "6":
                    case "jsonconstructorworkingexample":
                        new JsonConstructorWorkingExample().Run();
                        break;

                    case "7":
                    case "employeeDecoratedDifferentNames":
                        new EmployeeDecoratedDifferentNamesExample().Run();
                        break;

                    case "8":
                    case "constructorparameterorder":
                        new ConstructorParameterOrderExample().Run();
                        break;


                    case "9":
                        case "complexobjectwithcorrectcasing":
                        new ComplexObjectWithCorrectCasingExample().Run();
                        break;
                    case "":
                    case "?":
                    case "help":
                    default:
                        HelpText();
                        break;
                }
            }
        }
        static void WritePrompt()
        {
            Console.Write($"SerializationThings> ");
        }

        static void WelcomeText()
        {
            Console.WriteLine("This application demonstrates common problems with serialization to and from JSON.");
            Console.WriteLine("You can run this console application but the main value is in viewing the code.");
        }

        static void HelpText()
        {
            Console.WriteLine("The following commands are available:");
            Console.WriteLine("   Exit\t\t- Exits the application.");
            Console.WriteLine("1. Basic\t\t- Demonstrates basic serialization");
            Console.WriteLine("2. BasicRequired\t- Demonstrates deserialization failure with required properties");
            Console.WriteLine("3. NameCasing\t\t- Demonstrates deserialization failure with name casing");
            Console.WriteLine("4. ConstructorParameters\t- Demonstrates deserialization failure with constructor parameters");
            Console.WriteLine("5. JsonConstructorParameters\t- Demonstrates deserialization failure with JsonConstructor attribute");
            Console.WriteLine("6. JsonConstructorWorkingExample\t- Demonstrates deserialization success with JsonConstructor attribute");
            Console.WriteLine("7. EmployeeDecoratedDifferentNames\t- Demonstrates deserialization success with different property names");
            Console.WriteLine("8. ConstructorParameterOrder\t- Demonstrates deserialization failure with constructor parameter order");
            Console.WriteLine("9. ComplexObjectWithCorrectCasing\t- Demonstrates deserialization success with correct name casing");
        }
    }
}
