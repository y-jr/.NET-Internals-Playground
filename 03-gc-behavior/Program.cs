using System;

class FinalizableObject
{
    public int Id;

    public FinalizableObject(int id)
    {
        Id = id;
    }

    ~FinalizableObject()
    {
        // Simula trabalho de limpeza
        Console.WriteLine($"Finalizer executado para objeto {Id}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== GC Behavior ===\n");

        CreateShortLivedObjects();
        PromoteObjects();
        CreateFinalizableObjects();

        Console.WriteLine("\nForçando GC final...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("Memória total após GC: " + GC.GetTotalMemory(false) / 1024 + " KB");
        Console.WriteLine("\nFim do experimento.");
        Console.ReadLine();
    }

    // Gen0
    static void CreateShortLivedObjects()
    {
        Console.WriteLine("[Gen0] Criando objetos de curta duração...");
        for (int i = 0; i < 100_000; i++)
        {
            var obj = new object();
        }

        GC.Collect(0);
        Console.WriteLine("Gen0 coletada. Memória: " + GC.GetTotalMemory(false) / 1024 + " KB\n");
    }

    // Promoção para Gen1/Gen2
    static void PromoteObjects()
    {
        Console.WriteLine("[Promoção] Mantendo referências vivas...");
        //Essa referência permitirá que os objectos continuem vivos
        /*

                              
        */
        object[] survivors = new object[10_000]; 

        for (int i = 0; i < survivors.Length; i++)
        {
            survivors[i] = new object();
        }

        Console.WriteLine($"Geração inicial: {GC.GetGeneration(survivors[0])}");

        GC.Collect(0);
        Console.WriteLine($"Após GC Gen0: {GC.GetGeneration(survivors[0])}");

        GC.Collect(1);
        Console.WriteLine($"Após GC Gen1: {GC.GetGeneration(survivors[0])}");

        GC.Collect();
        Console.WriteLine($"Após Full GC: {GC.GetGeneration(survivors[0])} \n");
    }

    // Finalizers
    static void CreateFinalizableObjects()
    {
        Console.WriteLine("[Finalizers] Criando objetos com finalizer...");

        for (int i = 0; i < 5; i++)
        {
            new FinalizableObject(i);
        }

        Console.WriteLine("Objetos criados. Forçando GC...");
        GC.Collect();

        Console.WriteLine("Observe que finalizers ainda não rodaram completamente.");
    }
}
