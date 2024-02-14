using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Ingrese una opcion:");
                Console.WriteLine("1). Numero factorial ");
                Console.WriteLine("2). Calculadora ");
                Console.WriteLine("3). Mayor o menor ");
                int Opcion = Convert.ToInt32(Console.ReadLine());
                switch(Opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese un numero del 1 al 8 ");
                        int nume = Convert.ToInt32(Console.ReadLine());

                        switch (nume)
                        {
                            case 1:
                                int factorial = 1 * 1;
                                Console.WriteLine("El resultado fue:" + factorial);
                                break;

                            case 2:
                                int factorial2 =  2 * 1;
                                Console.WriteLine("El resultado fue:" + factorial2);
                                break;

                            case 3:
                                int factorial3 = 1 * 2 * 3;
                                Console.WriteLine("El resultado fue:" + factorial3);
                                break;

                            case 4:
                                int factorial4 = 1 * 2 * 3 * 4;
                                Console.WriteLine("El resultado fue:" + factorial4);
                                break;

                            case 5:
                                int factorial5 = 1 * 2 * 3 * 4 * 5;
                                Console.WriteLine("El resultado fue:" + factorial5);
                                break;
                            case 6:
                                int factorial6 = 1 * 2 * 3 * 4 * 5 *6;
                                Console.WriteLine("El resultado fue:" + factorial6);
                                break;

                            case 7:
                                int factorial7 = 1 * 2 * 3 * 4 * 5 * 6 * 7;
                                Console.WriteLine("El resultado fue:" + factorial7);
                                break;
                            
                            case 8:
                                int factorial8 = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8;
                                Console.WriteLine("El resultado fue:" + factorial8);
                                break;
                            default:
                                break;
                        }

                        break;

                        case 2:
                        Console.WriteLine("Ingrese un numero: ");
                        int num1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese un segundo numero: ");
                        int num2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese una opcion: ");
                        Console.WriteLine("1).Suma");
                        Console.WriteLine("2).Resta");
                        Console.WriteLine("3).Multiplicacion");
                        Console.WriteLine("4).Division");
                        int opc = Convert.ToInt32(Console.ReadLine());
                        switch (opc)
                        {
                    case 1:
                                int suma = num1 + num2;
                                Console.WriteLine("El resultado fue: " + suma);
                                break;

                            case 2:
                                int resta = num1 - num2;
                                Console.WriteLine("El resultado fue: " + resta);

                                break;

                                case 3:
                                 int multiplicacion = num1 * num2;
                                Console.WriteLine("El resultado fue: " + multiplicacion);
                                break;

                                case 4:
                                double division = num1 / num2;
                                Console.WriteLine("El resultado fue: " + division);
                                break;
                        }
                        break;

                        case 3:
                        Console.WriteLine("Ingrese un numero");
                        int numero1 = Convert.ToInt32(Console.ReadLine());
                        switch(numero1)
                        {
                            case int n when n < 20:
                                Console.WriteLine("El numero es menor que 20.");
                                break;
                            case int n when n == 20:
                                Console.WriteLine("El numero igual a 20.");
                                break;
                            case int n when n > 20:
                                Console.WriteLine("El numero es mayor que 20.");
                                break;
                            default:
                                Console.WriteLine("Opcio no valida");
                                break;
                        }
                        break;

                        default: Console.WriteLine("Ingrese una opcion valida...");
                        break;
                        

                }
            }
        }
    }
}
