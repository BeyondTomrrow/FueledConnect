namespace FueledConnect.Core.Interfaces;

public interface IUnitOfWork
{
    ISubmissionRepository Submissions { get;  }
    IRegistryRepository Registry { get;  }

    Task<int> SaveChangesASync(CancellationToken cancellationToken = default);
}