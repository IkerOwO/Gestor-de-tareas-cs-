using System;

namespace GestorDeTareas
{
    class Program
    {
        public class Archivo
        {
            public static string? nombreArchivo { get; set; }
            public static string? user { get; set; }
            public static string? ruta { get; set; }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Introduce el usuario del PC: ");
            Console.ResetColor();
            Archivo.user = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Introduce el nombre del archivo: ");
            Console.ResetColor();
            Archivo.nombreArchivo = Console.ReadLine();

            Archivo.ruta = $"C:\\Users\\{Archivo.user}\\Documents\\{Archivo.nombreArchivo}.txt";

            CrearArchivo(Archivo.user, Archivo.nombreArchivo, Archivo.ruta);
        }

        static void CrearArchivo(string? usuario, string? nombreArchivo, string? ruta)
        {
            try
            {
                if (!File.Exists($"C:\\Users\\{usuario}\\Documents\\{nombreArchivo}.txt"))
                {
                    File.Create($"C:\\Users\\{usuario}\\Documents\\{nombreArchivo}.txt");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Archivo creado con exito");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("El archivo ya existe.");
                    Console.ResetColor();
                }
                LeerArchivo(ruta);
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR AL CREAR EL ARCHIVO: {e.Message}");
                Console.ResetColor();
            }
        }
        
        static void LeerArchivo(string? ruta)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leyendo Archivo...");
            Console.ResetColor();
            Thread.Sleep(5000); // PAUSAR POR 5s
            Console.Clear();

            if(File.Exists(ruta))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("---------CONTENIDO DEL ARCHIVO---------\n");
                Console.ResetColor();
                // USAMOS StreamReader PORQUE LEE TODAS LAS LINEAS Y LAS IMPRIME TAL CUAL ESTAN ESCRITAS
                using (StreamReader sr = File.OpenText(ruta))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

        }
    }
}