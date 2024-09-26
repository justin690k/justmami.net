using justmami.Domain.Core;

namespace justmami.Domain.Entities;
public class User : Entity
{
    public required string Firstname { get; set; }
}
