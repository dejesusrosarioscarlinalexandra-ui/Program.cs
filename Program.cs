using System;
using Spectre.Console;


class Program
{
static void Main()
    {
        // Solicitar datos
        Console.Write("Ingrese el monto del préstamo: ");
        decimal monto = decimal.Parse(Console.ReadLine()!);

        Console.Write("Ingrese el interés anual: ");
        decimal interesAnual = decimal.Parse(Console.ReadLine()!);

        Console.Write("Ingrese el plazo mensual: ");
        int plazo = int.Parse(Console.ReadLine()!);

        // Convertir a interés mensual
        decimal interesMensual = (interesAnual / 12) / 100;

        // Calcular cuota fija
        decimal potencia = (decimal)Math.Pow(1 + (double)interesMensual, plazo);

        decimal cuota = monto *
                        (interesMensual * potencia) /
                        (potencia - 1);

        cuota = Math.Round(cuota, 2);

        // Crear tabla
        Table tabla = new Table();

        tabla.AddColumn("Cuota");
        tabla.AddColumn("Pago");
        tabla.AddColumn("Interés");
        tabla.AddColumn("Abono");
        tabla.AddColumn("Saldo");

        decimal saldo = monto;

        // Generar tabla
        for (int i = 1; i <= plazo; i++)
        {
            decimal interes = saldo * interesMensual;
            interes = Math.Round(interes, 2);

            decimal abono = cuota - interes;
            abono = Math.Round(abono, 2);

            saldo -= abono;
            saldo = Math.Round(saldo, 2);

            if (saldo < 0)
                saldo = 0;

            tabla.AddRow(
                i.ToString(),
                cuota.ToString("N2"),
                interes.ToString("N2"),
                abono.ToString("N2"),
                saldo.ToString("N2")
            );
        }

        // Mostrar tabla
        AnsiConsole.Write(tabla);

        Console.ReadKey();
    }
}