using Silk.DDD.Domain;
using System.Reflection;

namespace justmami.Test.Architecture;

public class DomainTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Domain_Entities_ShouldInheritFrom_EntityClass()
    {
        Assembly domainAssembly = Assembly.Load("justmami.Domain");

        Type entityBaseType = typeof(Entity);

        // Act
        IEnumerable<Type> allEntityTypes = domainAssembly
                 .GetTypes()
                 .Where(type => type.Namespace != null &&
                                type.Namespace.Contains("Domain.Entities") &&
                                type.IsClass && !type.IsAbstract);

        foreach (Type? entityType in allEntityTypes)
        {
            Assert.That(entityBaseType.IsAssignableFrom(entityType), Is.True,
                $"{entityType.Name} should inherit from {entityBaseType.Name}");
        }
    }
}