using Application02.Contracts.Commands;

namespace Application02.Application;

public class Validations
{
    private const string ERROR_MESSAGE = "DevEui is empty";
    public static async Task Validation(SensorStatusCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.DevEui)) throw new ArgumentException(ERROR_MESSAGE);
        await Task.CompletedTask;
    }
}