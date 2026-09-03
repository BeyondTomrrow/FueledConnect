namespace FueledConnect.Core.Entities;

public class Driver
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    //1-1 relationship with user account
    public Guid UserId { get; set; }
    public User User { get; set; } = null;
    
    //Driver Profile and hardware deets
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? DeviceId { get; set; }
    public DateTime? LastActive { get; set; }
    
    // many relationshipos history of all field submissions made by driver
    public List<FieldSubmission> FieldSubmissions { get; set; } = new();
}