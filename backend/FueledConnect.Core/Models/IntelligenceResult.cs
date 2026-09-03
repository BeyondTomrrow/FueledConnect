namespace FueledConnect.Core.Models;

public class IntelligenceResult
{
    public string LegacyString { get; set; } = string.Empty;
    public string AiSummary { get; set; } = string.Empty;
    public ExtractedEntities ExtractedEntities { get; set; } = new();
    
}

public class ExtractedEntities
{
    public string? CustomerName { get; set; }
    public string? GateCode { get; set; }
    public string? LocationName { get; set; }
    public List<string> Alerts { get; set; } = new();
}