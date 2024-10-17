using Silk.DDD.Infrastructure;
using System.Reflection;

namespace justmami.Test.Architecture;
public class InfrastructureTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Repositories_ShouldInheritFrom_IRepository_Interface()
    {
        Assembly infrastructureAssembly = Assembly.Load("justmami.Infrastructure");

        Type repositoryBaseType = typeof(IRepository<>);

        // Act
        IEnumerable<Type> allInfrastructureTypes = infrastructureAssembly
                 .GetTypes()
                 .Where(type => type.Namespace != null &&
                                type.Namespace.Contains("Infrastructure.Repositories") &&
                                type.IsClass && !type.IsAbstract);

        foreach (Type? infrastructureType in allInfrastructureTypes)
        {
            Assert.That(repositoryBaseType.IsAssignableFrom(infrastructureType), Is.True,
                $"{infrastructureType.Name} should inherit from {repositoryBaseType.Name}");
        }
    }
}
