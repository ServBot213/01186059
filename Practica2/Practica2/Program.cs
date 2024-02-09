using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while(!salir)
            {
                Console.WriteLine("Elige una opcion ");
                Console.WriteLine("1).Mayor de edad ");
                Console.WriteLine("2).Bisiesto o no ");
                Console.WriteLine("3).Calcular areas ");
                Console.WriteLine("4).Aprobo o reprobo ");
                Console.WriteLine("5).Leer edad ");
                Console.WriteLine("6).Par o impar ");
                Console.WriteLine("7).Numero mayor");
                Console.WriteLine("8).Funciones math");
                Console.WriteLine("9).Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {

                    case 1:
                        Console.WriteLine("Ingrese su edad: ");
                        int edad = Convert.ToInt32(Console.ReadLine()); 

                        if(edad >= 18)
                        {
                            Console.WriteLine("Si, es mayor");
                        }
                        else
                        {
                            Console.WriteLine("No, no es mayor");
                        }
                        
                        break;

                        case 2:
                        Console.WriteLine("Ingrese un año: ");
                        int anio = Convert.ToInt32(Console.ReadLine()); 

                         if (anio % 4 == 0 && anio % 100 != 0 || anio % 400 == 0)
                        {
                            Console.WriteLine("Si es bisiesto");
                        }
                        else
                        {
                            Console.WriteLine("No, no es bisiesto");
                        }

                        break;

                        case 3:
                        Console.WriteLine("Ingrese una opcion ");
                        Console.WriteLine("1).Triangulo ");
                        Console.WriteLine("2).Circulo ");
                        Console.WriteLine("3).Rectangulo ");
                        int opcion2 = Convert.ToInt32(Console.ReadLine());
                        switch (opcion2)
                        {
                            case 1:
                                Console.WriteLine("Ingrese la base del triangulo");
                                double base1 = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Ingrese la altura");
                                double altura1 = Convert.ToDouble(Console.ReadLine());
                                double area = (base1 * altura1)/2;
                                Console.WriteLine("El resultado fue: " + area);

                                break;

                            case 2:
                                Console.WriteLine("Ingrese el radio del circulo");
                                double radio1 = Convert.ToDouble(Console.ReadLine());
                                double area2 = (radio1 * radio1)/3.1415;
                                Console.WriteLine("El resultado fue: " + area2);

                                break;

                            case 3:
                                Console.WriteLine("Ingrese la base del triangulo");
                                double base2 = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Ingrese la altura");
                                double altura2 = Convert.ToDouble(Console.ReadLine());
                                double area3 = (base2 * altura2);
                                Console.WriteLine("El resultado fue: " + area3);

                                break;
                        }


                        break;

                            
                        case 4:
                        Console.WriteLine("Ingrese una calificacion: ");
                        double prom1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese una segunda calificacion: ");
                        double prom2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese una tercera calificacion: ");
                        double prom3 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese una cuarta calificacion: ");
                        double prom4 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese una quinta calificacion: ");
                        double prom5 = Convert.ToDouble(Console.ReadLine());
                        double sumaprom = prom1 + prom2 + prom3 + prom4 + prom5;
                        double promedio = sumaprom / 5;
                        if(promedio  >= 60)
                        {
                            Console.WriteLine("El alumno aprobo ");
                        }
                        else
                        {
                            Console.WriteLine("El alumno no aprobo,su promedio fue " + promedio);                       }
                        break;

                       case 5:
                        Console.WriteLine("Es hombre o mujer? ");
                        String sexo = Console.ReadLine().ToLower();
                        if (sexo == "hombre")
                        {
                            Console.WriteLine("Ingrese su edad");
                            int yrs = Convert.ToInt32(Console.ReadLine());
                            if (yrs >= 18)
                            {
                                Console.WriteLine("Sexo: " + sexo);
                                Console.WriteLine("Edad: " + yrs);
                            }

                            else
                            {
                                Console.WriteLine("No es mayor....");
                            }
                        }
                        else
                        {
                               Console.WriteLine("No es hombre......");
                        }
                            break;

                        case 6:
                        Console.WriteLine("Ingrese un numero ");
                        int parimpar = Convert.ToInt32(Console.ReadLine());
                         if ((parimpar % 2) == 0)
                        {
                            Console.WriteLine("Es numero par");
                        }
                         else
                        {
                            Console.WriteLine("Es impar");    
                        }

                        break;

                        case 7:
                        Console.WriteLine("Ingrese un numero ");
                        int num1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese un segundo numero ");
                        int num2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese un tercer numero ");
                        int num3 = Convert.ToInt32(Console.ReadLine());
                        int resultado = Math.Max(num1,num2);
                        int resultado2 = Math.Max(resultado,num3);
                        Console.WriteLine("El numero mayor fue: " + resultado2);

                        break;

                        case 8:
                        Console.WriteLine("Ingrese un numero ");
                        double numeroabs = Convert.ToDouble(Console.ReadLine());
                        double valorAbsoluto = Math.Abs(numeroabs);
                        Console.WriteLine("Valor absoluto: " + valorAbsoluto);
                        double potencia = Math.Pow(numeroabs, 2);
                        Console.WriteLine("Potencia : " + potencia);
                        double raizCuadrada = Math.Sqrt(numeroabs);
                        Console.WriteLine("Raiz cuadrada: " + raizCuadrada);
                        double seno = Math.Sin(numeroabs);
                        Console.WriteLine("Seno: " + seno);
                        double coseno = Math.Cos(numeroabs);
                        Console.WriteLine("Coseno: " + coseno);
                        int redondeo = (int)Math.Round(numeroabs);
                        Console.WriteLine("Redondeo: " + redondeo);
                        int truncamiento = (int)Math.Truncate(numeroabs);
                        Console.WriteLine("Truncamiento: " + truncamiento);
                        break;  

                        case 9:
                        Console.WriteLine("Adios..");
                        salir = true;
                        break;
                    default: Console.WriteLine("Ingrese una opcion valida... ");
                        break;
                }
            }
        }
    }
}
