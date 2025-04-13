namespace Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;

public class ExternalDependencies
{
    public const string Key = nameof(ExternalDependencies);

    public string NotificationsRefitBase { get; init; }
    public string HttpBase { get; init; }
}
