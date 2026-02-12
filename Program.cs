// Variables y principales tipos de datos
string nombre;
string apellido;
int edad;
float altura;

// Entrada de datos
Console.Write("Nombre: ");
nombre = Console.ReadLine()!;

Console.Write("Apellido: ");
apellido = Console.ReadLine()!;

Console.Write("Edad: ");
edad = int.Parse(Console.ReadLine()!);

Console.Write("Altura: ");
altura = float.Parse(Console.ReadLine()!);

// Salida final
Console.WriteLine($"\nHola, mi nombre es {nombre} {apellido}");
Console.WriteLine($"Tengo {edad} años de edad");
Console.WriteLine($"Mi altura es {altura}");