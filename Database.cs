using Microsoft.Data.Sqlite;

namespace Bookcase.Database;

public class Database
{
    private readonly string _connectionString;

    public Database(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
    }

    public SqliteConnection GetConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public void Initialize()
    {
        using var connection = GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS miembro (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nombre_completo TEXT NOT NULL,
            cedula TEXT NOT NULL UNIQUE,
            telefono TEXT NOT NULL
        );
        ";

        command.ExecuteNonQuery();
    }
}