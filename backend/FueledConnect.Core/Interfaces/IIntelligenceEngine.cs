using FueledConnect.Core.Entities;
using FueledConnect.Core.Models;
namespace FueledConnect.Core.Interfaces;

public interface IIntelligenceEngine
{
    Task<IntelligenceResult> ProcessSubmissionAsync(
        FieldSubmission submission,
        CancellationToken cancellationToken = default);
}