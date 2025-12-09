using Application02.Contracts;
using Application02.Contracts.Commands;
using Application02.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application02.Infrastructure.EFCore;


public class SensorResourceRepository(AppDbContext context) : ISensorDataRepository
{
    public async Task<SensorResource> Add(SensorStatusCommand statusCommand, CancellationToken cancellationToken)
    {
        var entity = SensorMap.ToEntity(statusCommand);

        context.Sensors.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return SensorMap.ToResource(entity);
    }

    public async Task<IEnumerable<SensorResource>> GetAll(CancellationToken cancellationToken) =>
         await context.Sensors.Select(x => SensorMap.ToResource(x)).ToListAsync(cancellationToken);
}

public static class SensorMap
{
    public static SensorMessage ToEntity(SensorStatusCommand statusCommand) => new()
    {
        DevEui = statusCommand.DevEui,
        SensorId = statusCommand.SensorId,
        TimeStamp = statusCommand.TimeStamp,
        Occupied = statusCommand.Occupied,
        RawData = statusCommand.RawData
    };

    public static SensorResource ToResource(SensorMessage entity) => new()
    {
        DevEui = entity.DevEui,
        SensorId = entity.SensorId,
        TimeStamp = entity.TimeStamp,
        Occupied = entity.Occupied
    };
}