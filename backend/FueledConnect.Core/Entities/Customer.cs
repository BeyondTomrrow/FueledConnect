namespace FueledConnect.Core.Entities;

public class Customer
{
    public Guid Id {  get; set; } = Guid.NewGuid();
    public string Name {   get; set; } = string.Empty;
    public string? ContactInfo { get; set;  }
    public string? DefaultLegacyCode { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    //Nav property
    public List<ProcessedResult> ProcessedResults { get; set; } = new();

}