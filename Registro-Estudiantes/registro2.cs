using System.Text.Json;
using System.IO;

namespace Registro2
{
    internal class registro2
    {
        static void Main(string[] args)
        {
            
            try 
            {
                Dictionary<string, Estudiante> diccionario = new Dictionary<string, Estudiante>();
                string ruta = "registro.json";
                bool salida = true;
                if (File.Exists(ruta))
                {
                    string jasonLeido = File.ReadAllText(ruta);
                    diccionario = JsonSerializer.Deserialize<Dictionary<string,Estudiante>>(jasonLeido)
                        ?? new Dictionary<string,Estudiante>();
                }
                while (salida)
                {
                    Console.Clear();
                    Console.WriteLine("Registro de estudiantes");
                    Console.WriteLine("Seleccione una opción\n1. Agregar\n2. Editar\n3. Eliminar\n4. Buscar\n5. Cantidad Registrada\n6. Salir");
                    string opcion = Console.ReadLine();

                    while (!int.TryParse(opcion, out int result) || result < 1 || result > 6)
                    {
                        Console.WriteLine("Elija una opción correcta");
                        opcion = Console.ReadLine();
                    }
                    int opcionInt = int.Parse(opcion);

                    if (opcionInt == 1)
                    {
                        bool volver = true;
                        while (volver)
                        {
                            Console.WriteLine("Id del estudiante: ");
                            string id = Console.ReadLine();
                            if (diccionario.ContainsKey(id))
                            {
                                Console.WriteLine("El id ya existe");
                                volver = false;
                                Console.ReadKey();
                            }
                            else
                            {
                                Estudiante _estudiante = new Estudiante();
                                Console.WriteLine("Nombre del estudiante: ");
                                _estudiante.name = Console.ReadLine();
                                Console.WriteLine("Teléfono: ");
                                _estudiante.numero = Console.ReadLine();
                                Console.WriteLine("Carrera: ");
                                _estudiante.carrera = Console.ReadLine();
                                diccionario.Add(id, _estudiante);
                                Console.ReadKey();
                                volver = false;
                            }
                        }
                    }
                    else if (opcionInt == 2)
                    {
                        bool volver = true;
                        while (volver)
                        {
                            Console.WriteLine("Id del estudiante");
                            string id = Console.ReadLine();
                            if (!diccionario.ContainsKey(id))
                            {
                                Console.WriteLine("El id no existe");
                                volver = false;
                            }
                            else
                            {
                                Console.WriteLine("¿Qué quieres editar? ");
                                Console.WriteLine("1. Nombre\n2. Teléfono\n3. Carrera\n");
                                string opccion2 = Console.ReadLine();
                                if (Convert.ToInt16(opccion2) == 1)
                                {
                                    Console.WriteLine("Nuevo nombre");
                                    diccionario[id].name = Console.ReadLine();
                                }
                                else if (Convert.ToInt16(opccion2) == 2)
                                {
                                    Console.WriteLine("Nuevo teléfono");
                                    diccionario[id].numero = Console.ReadLine();
                                }
                                else if (Convert.ToInt16(opccion2) == 3)
                                {
                                    Console.WriteLine("Nueva carrera");
                                    diccionario[id].carrera = Console.ReadLine();
                                }
                                volver = false;
                            }
                        }
                    }
                    else if (opcionInt == 3)
                    {
                        bool volver = true;
                        while (volver)
                        {
                            Console.WriteLine("Id del estudiante");
                            string id = Console.ReadLine();
                            if (!diccionario.ContainsKey(id))
                            {
                                Console.WriteLine("El id no existe");
                                Console.ReadKey();
                                volver = false;
                            }
                            else
                            {
                                diccionario.Remove(id);
                                Console.WriteLine("Usuario eliminado");
                                Console.ReadKey();
                                volver = false;
                            }
                        }
                    }
                    else if (opcionInt == 4)
                    {
                        Console.WriteLine("Digite el id del estudiante");
                        string id = Console.ReadLine();
                        if (!diccionario.ContainsKey(id))
                        {
                            Console.WriteLine("El id no existe");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Nombre: " + diccionario[id].name);
                            Console.WriteLine("Número: " + diccionario[id].numero);
                            Console.WriteLine("Carrera: " + diccionario[id].carrera);
                            Console.ReadKey();
                        }
                    }
                    else if (opcionInt == 5)
                    {
                        Console.WriteLine("Estudiantes registrados: " + diccionario.Count);
                        Console.ReadKey();
                    }
                  
                    else if (opcionInt == 6)
                    {
                        string json = JsonSerializer.Serialize(diccionario, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(ruta, json);
                        salida = false;
                        Console.WriteLine("Gracias por usar el sistema");
                        Console.ReadKey();
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Hubo un error: " + ex.Message);
                Console.ReadKey();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Hubo un error: " + ex.Message);
                Console.ReadKey();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Hubo un error: " + ex.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error: " + ex.Message);
                Console.ReadKey();
            }
        }
        public class Estudiante
        {
            public string name { get; set; }
            public string numero { get; set; }
            public string carrera { get; set; }
        }
    }
}
