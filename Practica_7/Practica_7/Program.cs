using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                
                int a = 1;
                double b = 2.2;
                Console.WriteLine("1).Numeros originales");
                Console.WriteLine("2).Cambio de variable");
                Console.WriteLine("3).Cambio explicito");
                Console.WriteLine("4).Cadena a entero");
                Console.WriteLine("5).Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Primer numero : " + a);
                        Console.WriteLine("Segundo numero : " + b);
                        break;

                        case 2:
                        int d;
                        d = (int)b;
                        //No se puede convertir un entero a decimal
                        Console.WriteLine("Primer numero : " + a);
                        Console.WriteLine("Segundo numero : " + d);
                        break;

                    case 3:
                        int e;
                        //e = b;
                        //Marca error
                        Console.WriteLine("Primer numero : " + a);
                        Console.WriteLine("Segundo numero : " + b);
                        // Console.WriteLine("Segundo numero : " + e); No funciona de esta manera
                        //No se pudo realizar conversion
                        break;

                    case 4:
                        string cadena = "213";
                        int conversion = int.Parse(cadena);
                        Console.WriteLine(conversion);
                        
                        break;
                    case 5:
                        salir = true;
                        break;
                }

            }
        }
    }
}
