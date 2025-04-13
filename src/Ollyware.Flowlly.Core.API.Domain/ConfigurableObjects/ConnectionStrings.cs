using Ollyware.Flowlly.Core.API.Domain.Constants;

namespace Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;

public sealed class ConnectionStrings
{
    public const string Key = nameof(ConnectionStrings);

    public string ElasticSearch { get; init; }
    public string PostgreSql { get; init; }
    public string SqlLite { get; init; }
    public string MicrosoftSqlServer { get; init; }
    public string Oracle { get; init; }
    public string MySql { get; init; }
}
