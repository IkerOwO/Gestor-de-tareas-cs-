using System;
using System.Collections;

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
            public string? ruta { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Pulse una tecla para empezar...");
            Console.ReadKey();
            Console.Clear();

            string ruta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "tareas.txt"
            );

            CrearArchivo(ruta);
            menu(ruta);
           
        }

        public static void menu(string? ruta)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1.Ver Tareas\n2.Crear Tareas\n3.Salir");
            Console.ResetColor();
            int opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    LeerArchivo(ruta);
                    break;
                case 2:
                    CrearArchivo(ruta);
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    Thread.Sleep(5000);
                    break;
                default:
                    Console.WriteLine("OPCION NO VALIDA...");
                    break;
            }
        }

        public static void CrearArchivo(string? ruta)
        {
            Console.WriteLine("Creando Archivo...");
            Thread.Sleep(3000);
            Console.Clear();
            try
            {
                if (!File.Exists(ruta))
                {
                    File.Create(ruta).Close();
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
                if (resp?.ToLower() == "si")
                {
                    Console.Clear();
                    InsertarTarea(ruta);
                }
            }
        }

        public static void InsertarTarea(string? ruta)
        {
            List<string> tareasArray = new List<string>();
            Console.Write("Cuantas tareas desea agregar?: ");
            int numTareas = int.Parse(Console.ReadLine());
            Console.Clear();

            for (int i = 0; i < numTareas; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Introduce la tarea a realizar: ");
                Console.ResetColor();
                string? tarea = Console.ReadLine();
                tareasArray.Add($"{i + 1}. {tarea}");
                Console.Clear();
            }

            Console.WriteLine("Estas son las tareas que se van a agregar: \n");

            for (int j = 0; j < tareasArray.Count; j++)
            {
                Console.WriteLine(tareasArray[j]);
            }

            // ASI NO SOBREESCRIBIMOS
            File.AppendAllText(ruta, string.Join(Environment.NewLine, tareasArray) + Environment.NewLine);
        }
    }
}