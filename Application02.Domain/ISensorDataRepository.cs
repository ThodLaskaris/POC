using Application02.Contracts;
using Application02.Contracts.Commands;
using Application02.Contracts.Query;

namespace Application02.Domain;

public interface ISensorDataRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SensorResource> Add(SensorStatusCommand statusCommand, CancellationToken cancellationToken);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusQuery"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SensorResource>> GetAll(CancellationToken cancellationToken);
}