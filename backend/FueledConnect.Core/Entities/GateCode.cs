namespace FueledConnect.Core.Entities;

public class GateCode
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = string.Empty;
    public string? AssociatedLocation { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    
    //Nav property
    public List<ProcessedResult> ProcessedResults { get; set; } = new();
}
