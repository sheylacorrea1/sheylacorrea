using System;
using System.Collections.Generic;

class TorreHanoi
{
    // Pila para representar las varillas
    private Stack<int> source = new Stack<int>();
    private Stack<int> auxiliary = new Stack<int>();
    private Stack<int> destination = new Stack<int>();
    private int numDiscos;

    public TorreHanoi(int numDiscos)
    {
        this.numDiscos = numDiscos;
        for (int i = numDiscos; i >= 1; i--)
        {
            source.Push(i);
        }
    }

    public void Resolver()
    {
        MoverDiscos(numDiscos, source, destination, auxiliary);
    }

    private void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n > 0)
        {
            // Mover n-1 discos de origen a auxiliar, usando destino como auxiliar
            MoverDiscos(n - 1, origen, auxiliar, destino);

            // Mover el disco n de origen a destino
            destino.Push(origen.Pop());
            ImprimirEstado();

            // Mover n-1 discos de auxiliar a destino, usando origen como auxiliar
            MoverDiscos(n - 1, auxiliar, destino, origen);
        }
    }

    private void ImprimirEstado()
    {
        Console.WriteLine("Estado actual:");
        Console.WriteLine("Source: " + string.Join(", ", source.ToArray()));
        Console.WriteLine("Auxiliary: " + string.Join(", ", auxiliary.ToArray()));
        Console.WriteLine("Destination: " + string.Join(", ", destination.ToArray()));
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Ingrese el número de discos:");
        int numDiscos = int.Parse(Console.ReadLine());

        TorreHanoi torreHanoi = new TorreHanoi(numDiscos);
        torreHanoi.Resolver();
    }
}
