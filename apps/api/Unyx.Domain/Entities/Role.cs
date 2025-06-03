using Unyx.Domain.Enums;

namespace Unyx.Domain.Entities;

public class Role : BaseEntity
{
    public RoleType RoleType { get; set; }

    public List<User> Users { get; set; } = [];
}