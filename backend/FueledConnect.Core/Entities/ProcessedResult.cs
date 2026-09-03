using FueledConnect.Core.Enums;

namespace FueledConnect.Core.Entities;

public class ProcessedResult
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    // 1-1 relationship with FieldSubmission
    public Guid SubmissionId { get; set; }
    public FieldSubmission FieldSubmission { get; set; } = null!;
    
    // 40 Char Legacy AS400 string and AI Summary.
    public string LegacyString { get; set; } = string.Empty;
    public string? AiSummary { get; set; }
    
    // Status of the AI Processing pipeline
    public ProcessingStatus Status { get; set; } = ProcessingStatus.Pending;
    public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
    
    //Extracted Alerts (e.g, ['Tempature Spike', 'Gate Delay'])
    public List<string> Alerts { get; set; } = new();
    
    //Optional Foreign keys and navigation properties to Registry tables
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public Guid? GateCodeId { get; set; }
    public GateCode? GateCode { get; set; }
    
    public Guid? LocationId { get; set; }
    public Location? Location { get; set; }
    
}
