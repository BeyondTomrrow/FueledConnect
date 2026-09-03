using FueledConnect.Core.Enums;
namespace FueledConnect.Core.Entities;

public class User
{
    public Guid? Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string PasswordHash {get; set;} = string.Empty;
    public UserRole Role { get; set; } = UserRole.Driver;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // 1-1 nav property Present if the user has the driver role.
    public Driver? Driver { get; set; }
}