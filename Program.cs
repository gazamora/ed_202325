using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



    class Program
    {

        static Nodo nodo1;
        static Nodo nodo2;
        static Nodo nodo3;
        static Nodo nodo4;
        static Nodo nodo5;

    public static int opcionMenu = 0;
        public static string opcionMenuIngresada = null;
        public static string opcionMenuSeleccionada = null;

        public static int elemento;
        public static int tamanoLista = 0;
        public static int elementoTemporal = 0;

       class Nodo
    {
        public int dato;
        public Nodo elementoDerecha;
        public Nodo elementoIzquierda;
    }

    static void Main(string[] args)
    {

        Menu();

    }

    public static void header()
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Listas doblemente ligadas circulares");
        Console.WriteLine("Gustavo Adolfo Zamora Vargas");
        Console.WriteLine("20704 - Estructura de Datos");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("");
    }

    public static void Menu()
    {
        
        do
        {

            header();

            Console.WriteLine("Menú de opcionMenues:");
            Console.WriteLine("");
            Console.WriteLine("(1) Insertar elemento");
            Console.WriteLine("(2) Eliminar elemento");
            Console.WriteLine("(3) Imprimir elementos de la lista");
            Console.WriteLine("");
            Console.WriteLine("Presiona cualquier otra tecla para Salir...");
            Console.WriteLine("");
            Console.Write("Opción: ");

            opcionMenuSeleccionada = Console.ReadLine();

            Console.Clear();

            switch (opcionMenuSeleccionada)
            {
                case "1":
                    InsertarDatos();
                    break;
                case "2":
                    EliminarDatos();
                    break;
                case "3":
                    Imprimir(true);
                    break;
                default:
                    opcionMenu = 1;
                    break;
            }

        } while (opcionMenu == 0);
    }
    public static void InsertarDatos()
        {
            do
            {

                header();
                
                Console.WriteLine("OPCIÓN - Insertar elemento (solo números)");
                Console.WriteLine("");

                Console.Write("Ingresa un número: ");
                elemento = Int32.Parse(Console.ReadLine());

                Insertar();
                Imprimir();

                Console.WriteLine("");
                Console.Write("¿Quieres insertar opcionMenuIngresada dato a la lista ? ([S] Si, [N] No): ");
                opcionMenuIngresada = Console.ReadLine();

                Console.Clear();

            } while (opcionMenuIngresada.ToLower().Equals("s"));
        }

        public static void Insertar()
        {
            if(nodo1 == null)
            {
                nodo1 = new Nodo();
                nodo1.dato = elemento;
                nodo2 = nodo1;
                nodo1.elementoIzquierda = nodo2;
                nodo2.elementoDerecha = nodo1;

            }
            else
            {
                // ordernar
                if(elemento < nodo1.dato)
                {
                    nodo3 = new Nodo();
                    nodo3.dato = elemento;
                    nodo3.elementoDerecha = nodo1;
                    nodo1.elementoIzquierda = nodo3;
                    nodo1 = nodo3;
                    nodo1.elementoIzquierda = nodo2;
                    nodo2.elementoDerecha = nodo1;

                }
                else
                {
                    if(elemento > nodo2.dato)
                    {
                        nodo3 = new Nodo();
                        nodo3.dato = elemento;
                        nodo3.elementoIzquierda = nodo2;
                        nodo2.elementoDerecha = nodo3;
                        nodo2 = nodo3;
                        nodo2.elementoDerecha = nodo1;
                        nodo1.elementoIzquierda = nodo2;
                    }
                    else
                    {
                        nodo4 = nodo1;
                        nodo5 = nodo4.elementoDerecha;

                        while (elemento > nodo5.dato)
                        {
                            nodo4 = nodo5;
                            nodo5 = nodo5.elementoDerecha;
                        }

                        nodo3 = new Nodo();
                        nodo3.dato = elemento;
                        nodo4.elementoDerecha = nodo3;
                        nodo3.elementoIzquierda = nodo4;
                        nodo5.elementoIzquierda = nodo3;
                        nodo3.elementoDerecha = nodo5;
                    }
                }
            }

        tamanoLista++;

        }

        public static void EliminarDatos()
        {
            do
            {
                header();
                
                Console.WriteLine("OPCIÓN - Eliminar elementos de la lista");

                Imprimir();

                Console.WriteLine("");

                if (nodo1 == null)
                {
                    opcionMenuIngresada = "2";
                }
                else
                {
                    Console.Write("¿Realmente deseas eliminar un dato de la lista? ([S] Si, [N] No): ");
                    opcionMenuIngresada = Console.ReadLine();
                    Console.WriteLine("");
                }

                if (opcionMenuIngresada.ToLower().Equals("s"))
                {
                    Console.Write("Ingresa el dato de la lista a eliminar: ");
                    elemento = Int32.Parse(Console.ReadLine());

                    Eliminar();
                }

                Console.WriteLine("");

                Console.Clear();

            } while (opcionMenuIngresada.Equals("s"));
        }

        // eliminar elemento de la lista
        public static void Eliminar()
        {
            if(nodo1 == null)
            {
                Console.WriteLine("\nLa lista se encuentra vacía.\n");
                Console.ReadKey();
            }
            else if(nodo1 == nodo2)
            {
                if(elemento == nodo1.dato)
                {
                    elementoTemporal = nodo1.dato;
                    nodo1 = null;
                    nodo2 = null;

                    tamanoLista--;
                }
                else
                {
                    Console.WriteLine("\n El dato que ingresaste no existe en la lista.");
                    Console.ReadKey();

                    Console.Clear();
                    EliminarDatos();
                }

            }else if (elemento == nodo1.dato)
            {
                elementoTemporal = nodo1.dato;
                nodo3 = nodo1;
                nodo1 = nodo1.elementoDerecha;
                nodo1.elementoIzquierda = nodo2;

                tamanoLista--;
        }
            else if (elemento == nodo2.dato)
            {
                elementoTemporal = nodo2.dato;
                nodo3 = nodo2;
                nodo2 = nodo2.elementoIzquierda;
                nodo2.elementoDerecha = nodo1;

                tamanoLista--;
            }
            else
            {
                nodo4 = nodo1;
                nodo5 = nodo4.elementoDerecha;
                while(elemento != nodo5.dato && nodo5 != nodo2)
                {
                    nodo4 = nodo5;
                    nodo5 = nodo5.elementoDerecha;
                }

                if(nodo5 == nodo2)
                {
                    Console.WriteLine("\n El dato ingresado no existe\n");
                    Console.ReadKey();
                }
                else
                {
                    elementoTemporal = nodo5.dato;
                    nodo3 = nodo5.elementoDerecha;
                    nodo3.elementoIzquierda = nodo4;
                    nodo4.elementoDerecha = nodo3;

                    tamanoLista--;
            }
                
            }

        }

        // imprimir elementos de la lista
        public static void Imprimir(bool head  = false)
        {

            if (head)
            {
                Console.Clear();
                header();
                Console.WriteLine("OPCIÓN - Imprimir elementos de la lista");
                Console.WriteLine("");
        }
           
            if(tamanoLista > 0) {

                Console.WriteLine("");
                Console.WriteLine("La lista tiene (" + tamanoLista + ") elementos.");
                Console.WriteLine("");

                nodo3 = nodo1;

                while (nodo3 != nodo2)
                    {
                        Console.Write("[" + nodo3.dato + "]");
                        nodo3 = nodo3.elementoDerecha;
                    }

                    Console.WriteLine("[" + nodo3.dato + "]");

                }
            else
            {
                Console.WriteLine("\nNada que imprimir, la lista se encuentra vacía.");
                Console.ReadKey();
            }
        

        }




    }


   