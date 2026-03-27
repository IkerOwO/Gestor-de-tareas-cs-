using System;

namespace GestorDeTareas
{
    /*
        LÓGICA DEL PROGRAMA:
            - El usuario introduce el usuario del PC para poder crear el archivo en los documentos del usuario
            - El programa comprueba si el archivo "tareas.txt" ya existe, si existe lee de el. Si no existe pasa a que el usuario introduzca tareas
            - Una vez acaba de leer la función, esta pregunta al usuario si quiere introducir mas tareas, llamando a la función "InsertarTarea"
     */
    class Program
    {
        public class Archivo
        {
            public static string? user { get; set; }
            public static string? ruta { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Pulse una tecla para empezar...");
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Introduce el usuario del PC: ");
            Console.ResetColor();
            Archivo.user = Console.ReadLine();

            Archivo.ruta = $"C:\\Users\\{Archivo.user}\\Documents\\tareas.txt";

            CrearArchivo(Archivo.user, Archivo.ruta);
            Console.Clear();
        }

        public static void CrearArchivo(string? usuario, string? ruta)
        {
            try
            {
                if (!File.Exists($"C:\\Users\\{usuario}\\Documents\\tareas.txt"))
                {
                    File.Create($"C:\\Users\\{usuario}\\Documents\\tareas.txt");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Archivo creado con exito");
                    Console.ResetColor();
                    InsertarTarea(ruta);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("El archivo ya existe.");
                    Console.ResetColor();
                    LeerArchivo(ruta);
                }
                
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR AL CREAR EL ARCHIVO: {e.Message}");
                Console.ResetColor();
            }
        }

        public static void LeerArchivo(string? ruta)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leyendo Archivo...");
            Console.ResetColor();
            Thread.Sleep(5000); // PAUSAR POR 5s
            Console.Clear();

            if (File.Exists(ruta))
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
                Console.WriteLine("Desea escribir alguna tarea mas? (si/no): ");
                string? resp = Console.ReadLine();
                if (resp.ToLower().Equals("si"))
                {
                    InsertarTarea(ruta);
                }
                else
                {
                    Console.WriteLine("Saliendo del programa...");
                    Thread.Sleep(5000);
                }
            }
        }

        public static void InsertarTarea(string? ruta)
        {
                Console.Write("Escriba la tarea a realizar: ");

        }
    }
}