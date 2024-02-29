using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practica_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir) {
                Console.WriteLine("1. Primer problema ");
                Console.WriteLine("2. Segundo problema ");
                Console.WriteLine("3.Salir");
                int Opcion = Convert.ToInt32(Console.ReadLine());
                switch(Opcion)
                {
                    case 1:
                        string mensaje = "Hola amigos, como estan?";
                        char[] caracteres = mensaje.ToCharArray();
                        Array.Reverse(caracteres);
                        string alrevez = new string(caracteres);
                        Console.WriteLine("El texto es: " +mensaje);
                        Console.WriteLine("Contiene la siguiente cantidad de caracteres: " + mensaje.Length);
                        Console.WriteLine("El texto al revez es: "+alrevez);

                        break;

                    case 2:
                        Console.WriteLine("Ingrese un nombre");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Contiene la siguiente cantidad de caracteres: " + nombre.Length);
                        Console.WriteLine("Sin espacios: ");
                        Console.WriteLine(nombre.Replace(" ",""));
                        string nombre1 = nombre.ToLower();
                        string nombre2= nombre.ToUpper();
                        Console.WriteLine("Con minusculas: ");
                        Console.WriteLine(nombre1);
                        Console.WriteLine("Con mayusculas: ");
                        Console.WriteLine(nombre2);
                        Console.WriteLine("El cuarto caracter del nombre es:{0}", nombre[3]);
                        Console.WriteLine("");
                        string nombre3 = nombre.Replace(nombre,"Prueba de cambio");
                        Console.WriteLine(nombre3);
                        Console.WriteLine("De izquierda: ");
                        for(int i = 0; i < nombre.Length; i++)
                        {
                            Console.WriteLine(nombre[i] + "");
                        }
                        Console.WriteLine("De derecha: ");
                        for (int i = nombre.Length - 1; i >= 0; i--)
                        {
                            Console.WriteLine(nombre[i] + "");
                        }
                        string busca = ".";
                        int posicion = 0;
                        posicion = nombre.IndexOf(busca);
                        while(posicion > 0)
                        {
                            Console.WriteLine(" '.' Encontrando en la posicion: {0}",posicion);
                            posicion = nombre.IndexOf(busca, posicion+1);
                        }
                        Console.WriteLine("Fin de la busqueda"); 

                        break;

                    case 3:
                        salir = true;
                        break;

                        default: Console.WriteLine("Opcion invalida");
                        break;
                }
            }
        }
    }
}
