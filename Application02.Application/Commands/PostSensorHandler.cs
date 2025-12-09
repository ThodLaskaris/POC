using Application02.Contracts;
using Application02.Contracts.Commands;
using Application02.Domain;

namespace Application02.Application;

public class PostSensorHandler(ISensorDataRepository repository)
{
    
    public async Task<SensorResource> Add(SensorStatusCommand request, CancellationToken cancellationToken)
    {
        await Validations.Validation(request, cancellationToken);
        var _ = Decoder.DecodeBase64(request.RawData);
        return await repository.Add(request, cancellationToken);
    }
}