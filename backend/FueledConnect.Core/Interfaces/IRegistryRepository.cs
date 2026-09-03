using FueledConnect.Core.Entities;
namespace FueledConnect.Core.Interfaces;

public interface IRegistryRepository
{
    //Customer Reg
    Task<Customer?> GetCustomerByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Customer>> GetCustomersAsync(int page, int size, string? search, CancellationToken cancellationToken = default);
    Task<Customer> AddCustomerAsync(Customer customer, CancellationToken cancellationToken = default);

    // GateCode Registry
    Task<GateCode?> GetGateCodeByCodeAsync(string code, CancellationToken cancellationToken = default);
    Task<GateCode?> GetGateCodeByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<GateCode>> GetGateCodesAsync(CancellationToken cancellationToken = default);
    Task<GateCode> AddGateCodeAsync(GateCode gateCode, CancellationToken cancellationToken = default);

    // Location Registry
    Task<Location?> GetLocationByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<Location?> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Location>> GetLocationsAsync(CancellationToken cancellationToken = default);
    Task<Location> AddLocationAsync(Location location, CancellationToken cancellationToken = default);
}