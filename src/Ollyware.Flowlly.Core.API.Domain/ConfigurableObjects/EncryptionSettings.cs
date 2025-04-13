namespace Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;

public class EncryptionSettings
{
    public const string Key = nameof(EncryptionSettings);

    public string AesKey { get; init; } = string.Empty;
    public string AesIV { get; init; } = string.Empty;
}
