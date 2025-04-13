using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Ollyware.Flowlly.Core.API.Persistence.DatabaseConnectionFactory.ConnectionBases;

internal abstract class BaseDatabaseConnectionFactory
{
    protected async static Task<IDbConnection> CreateOracleConnection(string connectionString)
    => await new OracleConnection(connectionString).ConnectionIntegrity();

    protected async static Task<IDbConnection> CreatePostgreSqlConnection(string connectionString)
    => await new NpgsqlConnection(connectionString).ConnectionIntegrity();


    protected async static Task<IDbConnection> CreateMicrosoftSqlServerConnection(string connectionString)
    => await new SqlConnection(connectionString).ConnectionIntegrity();


    protected async static Task<IDbConnection> CreateSqlLiteConnection(string connectionString)
    => await new SqliteConnection(connectionString).ConnectionIntegrity();


    protected async static Task<IDbConnection> CreateMySqlConnection(string connectionString)
    => await new MySqlConnection(connectionString).ConnectionIntegrity();
}
