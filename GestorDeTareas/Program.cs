using System;

namespace GestorDeTareas
{
    class Program
    {
        private static string nombreArchivo { get; set; }
        private static string user { get; set; }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el usuario del PC: ");
            user = Console.ReadLine();
            Console.WriteLine("Introduce el nombre del archivo: ");
            nombreArchivo = Console.ReadLine();
            try
            {
                File.Create($"C:\\Users\\{user}\\Documents\\{nombreArchivo}.txt");
            } catch (Exception e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
    }
}