using System;

class Nodo
{
    public string fruta;
    public Nodo izquierda;
    public Nodo derecha;

    public Nodo(string fruta)
    {
        this.fruta = fruta;
        izquierda = null;
        derecha = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    // Insertar una fruta en el arbol
    public void Insertar(string fruta)
    {
        raiz = InsertarRecursivo(raiz, fruta);
    }

    private Nodo InsertarRecursivo(Nodo nodo, string fruta)
    {
        if (nodo == null)
        {
            nodo = new Nodo(fruta);
            return nodo;
        }

        // Insertar en la subrama izquierda o derecha, segun el orden alfabetico
        if (string.Compare(fruta, nodo.fruta) < 0)
            nodo.izquierda = InsertarRecursivo(nodo.izquierda, fruta);
        else if (string.Compare(fruta, nodo.fruta) > 0)
            nodo.derecha = InsertarRecursivo(nodo.derecha, fruta);

        return nodo;
    }

    // Buscar una fruta en el arbol
    public bool Buscar(string fruta)
    {
        return BuscarRecursivo(raiz, fruta);
    }

    private bool BuscarRecursivo(Nodo nodo, string fruta)
    {
        if (nodo == null)
            return false;

        if (nodo.fruta == fruta)
            return true;

        if (string.Compare(fruta, nodo.fruta) < 0)
            return BuscarRecursivo(nodo.izquierda, fruta);

        return BuscarRecursivo(nodo.derecha, fruta);
    }

    // Recorrido en InOrden (izquierda, raiz, derecha)
    public void InOrden()
    {
        InOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    private void InOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRecursivo(nodo.izquierda);
            Console.Write(nodo.fruta + " ");
            InOrdenRecursivo(nodo.derecha);
        }
    }

    // Recorrido en PreOrden (raiz, izquierda, derecha)
    public void PreOrden()
    {
        PreOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PreOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.fruta + " ");
            PreOrdenRecursivo(nodo.izquierda);
            PreOrdenRecursivo(nodo.derecha);
        }
    }

    // Recorrido en PostOrden (izquierda, derecha, raiz)
    public void PostOrden()
    {
        PostOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PostOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRecursivo(nodo.izquierda);
            PostOrdenRecursivo(nodo.derecha);
            Console.Write(nodo.fruta + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion = 0;

        do
        {
            Console.WriteLine("\nÁrbol Binario de Frutas");
            Console.WriteLine("1. Insertar una fruta");
            Console.WriteLine("2. Buscar una fruta");
            Console.WriteLine("3. Mostrar en InOrden");
            Console.WriteLine("4. Mostrar en PreOrden");
            Console.WriteLine("5. Mostrar en PostOrden");
            Console.WriteLine("6. Salir");
            Console.Write("Elija una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingresa el nombre de la fruta: ");
                    string fruta = Console.ReadLine();
                    arbol.Insertar(fruta);
                    Console.WriteLine($"Fruta '{fruta}' insertada.");
                    break;

                case 2:
                    Console.Write("Ingresa el nombre de la fruta a buscar: ");
                    string frutaBuscar = Console.ReadLine();
                    if (arbol.Buscar(frutaBuscar))
                        Console.WriteLine($"Fruta '{frutaBuscar}' encontrada.");
                    else
                        Console.WriteLine($"Fruta '{frutaBuscar}' no encontrada.");
                    break;

                case 3:
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.InOrden();
                    break;

                case 4:
                    Console.WriteLine("Recorrido PreOrden:");
                    arbol.PreOrden();
                    break;

                case 5:
                    Console.WriteLine("Recorrido PostOrden:");
                    arbol.PostOrden();
                    break;

                case 6:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion no valida, intente nuevamente.");
                    break;
            }
        } while (opcion != 6);
    }
}
