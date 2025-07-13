using System;

namespace prueba
{
    internal class calculadora
    {
        static void Main(string[] args)
        {
            bool salida = true;
            while (salida)
            {
                Console.Clear();
                Console.WriteLine("digite el numero de la operacion deseada");
                Console.WriteLine("1.suma\n2.resta\n3.Multplicacion\n4.Division\n5.Modulo\n6.Salir");
                String p = Console.ReadLine();
                while (!int.TryParse(p, out int result) || result < 1 || result > 6)
                {
                    Console.WriteLine("Elija una opcion correcta");
                    p = Console.ReadLine();
                }
                try
                {
                    if (Convert.ToInt32(p) == 1)
                    {
                        Console.Write("num1: ");
                        decimal num1 = decimal.Parse(Console.ReadLine());
                        Console.Write("num2: ");
                        decimal num2 = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(Suma(num1, num2));
                        Console.ReadKey();
                    }
                    else if (Convert.ToInt16(p) == 2)
                    {
                        Console.Write("num1: ");
                        decimal num1 = decimal.Parse(Console.ReadLine());
                        Console.Write("num2: ");
                        decimal num2 = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(Resta(num1, (int)num2));
                        Console.ReadKey();

                    }
                    else if (Convert.ToInt16(p) == 3)
                    {
                        Console.Write("num1: ");
                        decimal num1 = decimal.Parse(Console.ReadLine());
                        Console.Write("num2: ");
                        decimal num2 = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(Multiplicacion(num1, (int)num2));
                        Console.ReadKey();
                    }
                    else if (Convert.ToInt16(p) == 4)
                    {
                        Console.Write("num1: ");
                        decimal num1 = decimal.Parse(Console.ReadLine());
                        Console.Write("num2: ");
                        decimal num2 = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(Division(num1, num2));
                        Console.ReadKey();
                    }
                    else if (Convert.ToInt16(p) == 5)
                    {
                        Console.Write("num1: ");
                        decimal num1 = decimal.Parse(Console.ReadLine());
                        Console.Write("num2: ");
                        decimal num2 = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(Modulo(num1, (int)num2));
                        Console.ReadKey();
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
                    Console.WriteLine("Hubo un error: "+ ex.Message);
                    Console.ReadKey();
                }
                if ((Convert.ToInt16(p) == 6))
                {
                    salida = false;
                    Console.WriteLine("Gracias por utilizar la calculadora");
                    Console.ReadKey();
                }
                
            }
        }
        public static decimal Suma(decimal num1, decimal num2)
        {
            Console.WriteLine("reslutado:");
            return num1 + num2;

        }
        public static decimal Division(decimal num1, decimal num2)
        {
            Console.WriteLine("reslutado:");
            return num1 / num2;
        }
        public static decimal Resta(decimal num1, int num2)
        {
            Console.WriteLine("reslutado:");
            return num1 - num2;
        }
        public static decimal Multiplicacion(decimal num1, int num2)
        {
            Console.WriteLine("reslutado:");
            return num1 * num2;
        }
        public static decimal Modulo(decimal num1, int num2)
        {
            Console.WriteLine("reslutado:");
            return num1 % num2;
        }

    }
}
