using Spectre.Console;
using Bookcase.Services;

namespace Bookcase.Screens;

public class MainScreen
{
    private readonly MiembroService _service;

    public MainScreen(MiembroService service)
    {
        _service = service;
    }

    public void Show()
    {
        bool running = true;

        while (running)
        {
            var opcion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("MENÚ GIMNASIO")
                .AddChoices(
                    "1. Registrar",
                    "2. Listar",
                    "3. Buscar",
                    "4. Actualizar",
                    "5. Eliminar",
                    "6. Salir"
                )
            );

            switch (opcion)
            {
                case "1. Registrar":
                    var n = AnsiConsole.Ask<string>("Nombre:");
                    var c = AnsiConsole.Ask<string>("Cédula:");
                    var t = AnsiConsole.Ask<string>("Teléfono:");
                    _service.Crear(n, c, t);
                    break;

                case "2. Listar":
                    var tabla = new Table();
                    tabla.AddColumn("ID");
                    tabla.AddColumn("Nombre");
                    tabla.AddColumn("Cédula");
                    tabla.AddColumn("Teléfono");

                    foreach (var m in _service.GetAll())
                    {
                        tabla.AddRow(
                            m.Id.ToString(),
                            m.NombreCompleto,
                            m.Cedula,
                            m.Telefono
                        );
                    }

                    AnsiConsole.Write(tabla);
                    break;

                case "3. Buscar":
                    var ced = AnsiConsole.Ask<string>("Cédula:");
                    var res = _service.Buscar(ced);

                    if (res != null)
                        AnsiConsole.WriteLine(res.NombreCompleto);
                    else
                        AnsiConsole.WriteLine("No encontrado");
                    break;

                case "4. Actualizar":
                    var ced2 = AnsiConsole.Ask<string>("Cédula:");
                    var tel = AnsiConsole.Ask<string>("Nuevo teléfono:");
                    _service.Actualizar(tel, ced2);
                    break;

                case "5. Eliminar":
                    var ced3 = AnsiConsole.Ask<string>("Cédula:");
                    _service.Eliminar(ced3);
                    break;

                case "6. Salir":
                    running = false;
                    break;
            }
        }
    }
}