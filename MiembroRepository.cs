using Microsoft.Data.Sqlite;
using Bookcase.Models;

namespace Bookcase.Repository;

public class MiembroRepository
{
    private readonly global::Bookcase.Database.Database _db;

    public MiembroRepository(global::Bookcase.Database.Database db)
    {
        _db = db;
    }

    public List<MiembroModel> SelectAll()
    {
        using var connection = _db.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM miembro;";

        using var reader = command.ExecuteReader();

        var lista = new List<MiembroModel>();

        while (reader.Read())
        {
            lista.Add(new MiembroModel
            {
                Id = reader.GetInt32(0),
                NombreCompleto = reader.GetString(1),
                Cedula = reader.GetString(2),
                Telefono = reader.GetString(3)
            });
        }

        return lista;
    }

    public MiembroModel? GetByCedula(string cedula)
    {
        using var connection = _db.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM miembro WHERE cedula = @cedula;";
        command.Parameters.AddWithValue("@cedula", cedula);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new MiembroModel
            {
                Id = reader.GetInt32(0),
                NombreCompleto = reader.GetString(1),
                Cedula = reader.GetString(2),
                Telefono = reader.GetString(3)
            };
        }

        return null;
    }

    public void Insert(string nombre, string cedula, string telefono)
    {
        using var connection = _db.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = @"
        INSERT INTO miembro (nombre_completo, cedula, telefono)
        VALUES (@nombre, @cedula, @telefono);
        ";

        command.Parameters.AddWithValue("@nombre", nombre);
        command.Parameters.AddWithValue("@cedula", cedula);
        command.Parameters.AddWithValue("@telefono", telefono);

        command.ExecuteNonQuery();
    }

    public void UpdateTelefono(string telefono, string cedula)
    {
        using var connection = _db.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = @"
        UPDATE miembro
        SET telefono = @telefono
        WHERE cedula = @cedula;
        ";

        command.Parameters.AddWithValue("@telefono", telefono);
        command.Parameters.AddWithValue("@cedula", cedula);

        command.ExecuteNonQuery();
    }

    public void Delete(string cedula)
    {
        using var connection = _db.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "DELETE FROM miembro WHERE cedula = @cedula;";
        command.Parameters.AddWithValue("@cedula", cedula);

        command.ExecuteNonQuery();
    }
}