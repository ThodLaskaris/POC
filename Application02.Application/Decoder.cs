namespace Application02.Application;

public static  class Decoder
{
    public static byte[]? DecodeBase64(string? rawData)
    {
        if (string.IsNullOrWhiteSpace(rawData))
            return null;

        try
        {
            return Convert.FromBase64String(rawData);
        }
        catch (FormatException)
        {
            return null;
        }
    }
}