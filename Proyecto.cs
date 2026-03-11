class Program
{
    static void Main()
    {
        // Capturar datos
        decimal monto = CapturarMonto();
        decimal interesAnual = CapturarInteres();
        int plazo = CapturarPlazo();

        // Calcular cuota
        decimal interesMensual = CalcularInteresMensual(interesAnual);
        decimal cuota = CalcularCuota(monto, interesMensual, plazo);

        // Generar tabla
        Table tabla = GenerarTabla(monto, interesMensual, plazo, cuota);

        // Mostrar resultados
        MostrarTabla(tabla);

        Console.ReadKey();
    }

    // ================== MÉTODOS ==================

    static decimal CapturarMonto()
    {
        Console.Write("Ingrese el monto del préstamo: ");
        return decimal.Parse(Console.ReadLine()!);
    }

    static decimal CapturarInteres()
    {
        Console.Write("Ingrese el interés anual (%): ");
        return decimal.Parse(Console.ReadLine()!);
    }

    static int CapturarPlazo()
    {
        Console.Write("Ingrese el plazo (meses): ");
        return int.Parse(Console.ReadLine()!);
    }

    static decimal CalcularInteresMensual(decimal interesAnual)
    {
        return (interesAnual / 12) / 100;
    }

    static decimal CalcularCuota(decimal monto, decimal interesMensual, int plazo)
    {
        decimal potencia = (decimal)Math.Pow(1 + (double)interesMensual, plazo);

        decimal cuota = monto *
                        (interesMensual * potencia) /
                        (potencia - 1);

        return Math.Round(cuota, 2);
    }

    static Table GenerarTabla(decimal monto, decimal interesMensual, int plazo, decimal cuota)
    {
        Table tabla = new Table();

        tabla.AddColumn("Cuota");
        tabla.AddColumn("Pago");
        tabla.AddColumn("Interés");
        tabla.AddColumn("Abono");
        tabla.AddColumn("Saldo");

        decimal saldo = monto;

        for (int i = 1; i <= plazo; i++)
        {
            decimal interes = Math.Round(saldo * interesMensual, 2);

            decimal abono = Math.Round(cuota - interes, 2);

            saldo = Math.Round(saldo - abono, 2);

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

        return tabla;
    }

    static void MostrarTabla(Table tabla)
    {
        AnsiConsole.Write(tabla);
    }
}

