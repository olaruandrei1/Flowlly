using System.Data;
using System.Data.Common;

namespace Ollyware.Flowlly.Core.API.Persistence.DatabaseConnectionFactory.ConnectionBases;

internal static class ConnectionHelpers
{
    internal static async Task<IDbConnection> ConnectionIntegrity(this IDbConnection connection)
    {
        if (connection.State is ConnectionState.Closed)
            if(connection is DbConnection dbConnection)
                await dbConnection.OpenAsync();
            else
                connection.Open();
        return connection;
    }
}
