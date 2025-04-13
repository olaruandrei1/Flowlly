using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;
using Ollyware.Flowlly.Core.API.Domain.Constants;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseConnectionFactory.ConnectionBases;
using System.Data;

namespace Ollyware.Flowlly.Core.API.Persistence.DatabaseConnectionFactory;

internal sealed class DbConnectionFactory(ConnectionStrings connectionStrings) : BaseDatabaseConnectionFactory, IDbConnectionFactory
{
    public async Task<IDbConnection> InitializeConnection(Databases databases) => databases switch
    {
        Databases.MicrosoftSqlServer => await CreateMicrosoftSqlServerConnection(connectionString: connectionStrings.MicrosoftSqlServer),
        Databases.Oracle => await CreateOracleConnection(connectionString: connectionStrings.Oracle),
        Databases.MySql => await CreateMySqlConnection(connectionString: connectionStrings.MySql),
        Databases.PostgreSql => await CreatePostgreSqlConnection(connectionString: connectionStrings.PostgreSql),
        Databases.SqlLite => await CreateSqlLiteConnection(connectionString: connectionStrings.SqlLite),
        _ => throw new NotImplementedException(message: $"{databases} is not implemented!")
    };
}
