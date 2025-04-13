namespace Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;

public sealed class ElasticConfigurations
{
    public const string Key = nameof(ElasticConfigurations);

    public string IndexName { get; init; }
}
