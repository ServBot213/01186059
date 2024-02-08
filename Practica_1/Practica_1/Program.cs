using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1) Suma ");
                Console.WriteLine("2) Altas ");
                Console.WriteLine("3) Salario ");
                Console.WriteLine("4) Numero ");
                Console.WriteLine("5) Salir ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese dos numeros:");
                        double num1 = double.Parse(Console.ReadLine());
                        double num2 = double.Parse(Console.ReadLine());

                        double suma = num1 + num2;
                        Console.WriteLine("La suma fue " + suma);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese su nombre ");
                        String nom;
                        nom = Console.ReadLine(); 
                        Console.WriteLine("Ingrese su profesion ");
                        String prof;
                        prof = Console.ReadLine();  
                        Console.WriteLine("Ingrese su edad ");
                        int edad = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese su genero ");
                        String gen;
                        gen = Console.ReadLine();   
                        Console.WriteLine("Nombre: " + nom);
                        Console.WriteLine("Profesion: " + prof);
                        Console.WriteLine("Edad: " + edad);
                        Console.WriteLine("Genero: " + gen);
                        break;

                    case 3:
                        Console.WriteLine("Cuantas horas trabajo a la semana?");
                        int horas = Convert.ToInt32(Console.ReadLine());
                        int sueldo = 50;
                        int horaextra = 100;
                        int salario;
                        if(horas <= 40)
                        {
                            salario = horas * sueldo;
                        }
                        else
                        {
                            int extra = horas - 40;
                            salario = (40 * sueldo) + (extra * horaextra);
                        }
                        Console.WriteLine("Su salario fue de : " + salario);
                        break;

                    case 4:
                        Console.WriteLine("Ingrese un numero de 3 digitos: ");
                        int numero = Convert.ToInt32(Console.ReadLine());
                        if (numero >= 100 && numero <= 999)
                        {
                            int nume1 = numero % 10;
                            int nume2 = (numero / 10) % 10;
                            int nume3 = numero / 100;
                            int inversion = nume1 * 100 + nume2 * 10 + nume3;
                            Console.WriteLine("Numero: " + numero);
                            Console.WriteLine("Invertido: " + inversion);
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un numero de 3 cifras");
                        }
                        break;

                    case 5:
                        salir = true;
                        break;

                    default: Console.WriteLine("Opcion invalida");
                        break;

                }
            }
            
            }
    }
}
