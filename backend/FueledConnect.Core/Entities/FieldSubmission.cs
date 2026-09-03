using FueledConnect.Core.Enums;

namespace FueledConnect.Core.Entities;

public class FieldSubmission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DriverId { get; set;  }
    public Driver? Driver { get; set; }
    public TrackType TrackType { get; set; }
    public string? RawVoiceText {  get; set; }
    public string? RawNotes { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<string> PhotoUrls { get; set; } = new();

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    // Nav property: One submission has processed AI result.
    public ProcessedResult? ProcessedResult { get; set; }
}