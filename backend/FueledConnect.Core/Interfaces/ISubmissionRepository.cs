using FueledConnect.Core.Entities;

namespace FueledConnect.Core.Interfaces;

public interface ISubmissionRepository
{
    Task<FieldSubmission> AddAsync(FieldSubmission fieldSubmission, CancellationToken cancellationToken = default);
    Task<FieldSubmission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<FieldSubmission>> GetByDriverIdAsync(Guid driverId, CancellationToken cancellationToken = default);
    Task<List<FieldSubmission>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<List<FieldSubmission>> SearchAsync(string? query, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken = default);
    Task UpdateAsync(FieldSubmission submission, CancellationToken cancellationToken = default);
}