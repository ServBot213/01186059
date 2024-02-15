using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_4
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            bool salir = false;
            while (!salir) { 
            Console.WriteLine("Ingrese una opcion: ");
            Console.WriteLine("1).Calificaciones ");
            Console.WriteLine("2).Numeros pares ");
            Console.WriteLine("3).Numeros impares ");
            Console.WriteLine("4).Banco ");
            Console.WriteLine("5).Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Cuantas calificaciones va a ingresar?");
                        int calif = Convert.ToInt32(Console.ReadLine());
                        int sumacal = 0;
                        for (int x = 0; x < calif; x++)
                        {
                            Console.WriteLine("Ingrese una calificacion: ");
                            int cal = Convert.ToInt32(Console.ReadLine());
                            sumacal += cal;
                        }
                        int promedio = sumacal / calif;
                        Console.WriteLine("El promedio fue: " + promedio);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese un valir inicial:");
                        int val1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese un valor final");
                        int val2 = Convert.ToInt32(Console.ReadLine());
                        if (val1 % 2 != 0) 
                        {
                            val1++; 
                        }
                        bool hayNumerosPares = false;
                        Console.WriteLine("Numeros pares :");
                        for (int x = val1; x <= val2; x += 2) 
                        {
                            Console.WriteLine(x);
                            hayNumerosPares = true; 
                        }
                        if (!hayNumerosPares)
                        {
                            Console.WriteLine("No hay numeros");
                        }
                        break;


                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Ingrese un valir inicial:");
                        int val3 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese un valor final");
                        int val4 = Convert.ToInt32(Console.ReadLine());
                        if (val3 % 2 == 0)
                        {
                            val3++;
                        }
                        bool hayNumerosPares2 = false;
                        Console.WriteLine("Numeros pares :");
                        for (int x = val3; x <= val4; x += 2)
                        {
                            Console.WriteLine(x);
                            hayNumerosPares = true;
                        }
                        if (!hayNumerosPares2)
                        {
                            Console.WriteLine("No hay numeros");
                        }
                        break;

                    case 4:
                        int opcion2;
                        int dinero = 0;
                        do
                        {
                            Console.WriteLine("Buen dia ingrese una opcion: ");
                            Console.WriteLine("1)Depositar");
                            Console.WriteLine("2)Retirar");
                            Console.WriteLine("3)Finalizar");
                            opcion2 = Convert.ToInt32(Console.ReadLine());
                            switch (opcion2)
                            {
                                case 1:
                                    Console.WriteLine("Cuanto va a depositar: ");
                                    int deposito = Convert.ToInt32(Console.ReadLine());
                                    dinero += deposito;
                                    break;

                                case 2:
                                    Console.WriteLine("Cuanto va a retirar: ");
                                    int retiro = Convert.ToInt32(Console.ReadLine());
                                    dinero -= retiro;

                                    break;
                                case 3:
                                    Console.WriteLine("Su cuenta quedo en " +dinero);
                                    break;
                                    
                        default: Console.WriteLine("Ingrese una opcion");
                                    break;
                            }
                        } while (opcion2 != 3);

                        break;

                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida...");

                        break;
                }
            }
        }
    }
}
