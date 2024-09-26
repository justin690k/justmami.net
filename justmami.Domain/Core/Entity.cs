namespace justmami.Domain.Core;
public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public override bool Equals(object obj) => obj is Entity other && Id.Equals(other.Id);

    public override int GetHashCode() => Id.GetHashCode();
}
