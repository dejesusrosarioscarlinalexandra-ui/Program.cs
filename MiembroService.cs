using Bookcase.Repository;
using Bookcase.Models;

namespace Bookcase.Services;

public class MiembroService
{
    private readonly MiembroRepository _repo;

    public MiembroService(MiembroRepository repo)
    {
        _repo = repo;
    }

    public List<MiembroModel> GetAll() => _repo.SelectAll();

    public MiembroModel? Buscar(string cedula)
        => _repo.GetByCedula(cedula);

    public void Crear(string nombre, string cedula, string telefono)
        => _repo.Insert(nombre, cedula, telefono);

    public void Actualizar(string telefono, string cedula)
        => _repo.UpdateTelefono(telefono, cedula);

    public void Eliminar(string cedula)
        => _repo.Delete(cedula);
}