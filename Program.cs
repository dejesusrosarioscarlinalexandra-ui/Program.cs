// Variables y principales tipos de datos
string nombre = "Scarlin";
string apellido = "De Jesus";
/*
  En C#, los números enteros son un tipo de valor que representa números sin decimales. Los números enteros en C# incluyen los siguientes tipos: byte, short, int, long.
*/
int edad = 19;

/*
  Los números flotantes en C# incluyen los siguientes tipos: float y double.
*/

Console.WriteLine($"Hola, mi nombre es {nombre} {apellido}");
Console.WriteLine("Tengo " + edad + " años de edad.\n");


// Entrada de datos
Console.Write("Nombre: ");
string? nombreUsuario = Console.ReadLine(); // El símbolo ? indica que puede ser string o null

Console.Write("Apellido: ");
string? apellidoUsuario = Console.ReadLine();

Console.Write("Edad: ");
int edadUsuario = int.Parse(Console.ReadLine()!);

Console.Write("Altura: ");
float alturaUsuario = float.Parse(Console.ReadLine()!);

// Salida final
Console.WriteLine($"¡Bienvenido {nombreUsuario} {apellidoUsuario}!");
Console.WriteLine($"Edad: {edadUsuario}");
Console.WriteLine($"Altura: {alturaUsuario}");
