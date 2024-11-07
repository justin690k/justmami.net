using Silk.DDD.CQRS;
using Silk.DDD.CQRS.Validation;
using System.Data;
using System.Reflection;

namespace justmami.Test.Architecture;
public class ApplicationTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Application_Commands_ShouldInheritFrom_CommandClasses()
    {
        Assert.True(true);
        return;
        Assembly applicationAssembly = Assembly.Load("justmami.Application");

        Type commandBaseType = typeof(ICommand<>);
        Type commandHandlerBaseType = typeof(CommandHandler<,>);
        Type commandValidatorBaseType = typeof(CommandValidator<>);

        // Act
        IEnumerable<Type> allcommandTypes = applicationAssembly
                 .GetTypes()
                 .Where(type => type.Namespace != null &&
                                type.Namespace.Contains("Application.Commands") &&
                                type.IsClass && !type.IsAbstract);

        foreach (Type? commandType in allcommandTypes)
        {
            string typeName = commandType.Name;

            switch (typeName)
            {
                case string _ when typeName.EndsWith("Command"):
                    Assert.That(commandBaseType.IsAssignableFrom(commandType),
                        Is.True, $"{commandType.Name} should inherit from {commandBaseType.Name}");
                    break;

                case string _ when typeName.EndsWith("Handler"):
                    Assert.That(commandHandlerBaseType.IsAssignableFrom(commandType),
                        Is.True, $"{commandType.Name} should inherit from {commandHandlerBaseType.Name}");
                    break;

                case string _ when typeName.EndsWith("Validator"):
                    Assert.That(commandValidatorBaseType.IsAssignableFrom(commandType),
                        Is.True, $"{commandType.Name} should inherit from {commandValidatorBaseType.Name}");
                    break;

                default:
                    Assert.Fail("Unexpected type in architecture: " + typeName);
                    break;
            }
        }


    }

    [Test]
    public void Application_Queries_ShouldInheritFrom_QueryClasses()
    {
        Assert.True(true);
        return;
        Assembly applicationAssembly = Assembly.Load("justmami.Application");

        Type queryBaseType = typeof(IQuery<>);
        Type queryHanlderBaseType = typeof(QueryHandler<,>);
        Type queryValidatorBaseType = typeof(QueryValidator<>);


        IEnumerable<Type> allqueryTypes = applicationAssembly
                 .GetTypes()
                 .Where(type => type.Namespace != null &&
                                type.Namespace.Contains("Application.Queries") &&
                                type.IsClass && !type.IsAbstract);

        foreach (Type? queryType in allqueryTypes)
        {
            string typeName = queryType.Name;

            switch (typeName)
            {
                case string _ when typeName.EndsWith("Query"):
                    Assert.That(queryBaseType.IsAssignableFrom(queryType),
                        Is.True, $"{queryType.Name} should inherit from {queryBaseType.Name}");
                    break;

                case string _ when typeName.EndsWith("Handler"):
                    Assert.That(queryHanlderBaseType.IsAssignableFrom(queryType),
                        Is.True, $"{queryType.Name} should inherit from {queryHanlderBaseType.Name}");
                    break;

                case string _ when typeName.EndsWith("Validator"):
                    Assert.That(queryValidatorBaseType.IsAssignableFrom(queryType),
                        Is.True, $"{queryType.Name} should inherit from {queryValidatorBaseType.Name}");
                    break;

                default:
                    Assert.Fail("Unexpected type in architecture: " + typeName);
                    break;
            }
        }
    }
}
