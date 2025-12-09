using Application02.Contracts;
using Application02.Contracts.Query;
using Application02.Domain;

namespace Application02.Application.Query;

public class GetSensorHandler(ISensorDataRepository repository)
{
    public async Task<IEnumerable<SensorResource>> GetAll(CancellationToken cancellationToken) => 
        await repository.GetAll(cancellationToken);
}