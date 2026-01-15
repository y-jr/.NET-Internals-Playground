using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Experimento CLR, JIT e GC ===\n");

        Console.WriteLine("Início do experimento");

        // Chama métodos separados para evidenciar JIT
        AllocateSmallObjects(); //Alocação de objetos pequenos (Gen0)
        AllocateLargeObject(); //Alocação de objectos grandes (Gen2)

        Console.WriteLine("Experimento concluído.");
        Console.ReadLine();
    }

    static void AllocateSmallObjects()
    {
        Console.WriteLine("\n[Small Objects]\n Criando 1.000.000 objetos pequenos...");
        for (int i = 0; i < 1_000_000; i++)
        {
            var obj = new object();
            // Observando a geração dos objectos pequenos (Primeiros 3 como exemplos)
            if (i < 3) Console.WriteLine($"\n Geração do obj-{i}: {GC.GetGeneration(obj)}");
        }
        Console.WriteLine("Objetos pequenos criados e coletáveis.");
        Console.WriteLine($"\nMemória total antes do GC: {GC.GetTotalMemory(false) / 1024} KB");

        Console.WriteLine("\nForçando coleta de GC para objetos pequenos (Gen0)...");
        GC.Collect(0);
        Console.WriteLine($"Memória total após GC: {GC.GetTotalMemory(false) / 1024} KB");
    }

    static void AllocateLargeObject()
    {
        Console.WriteLine("\n[Large Object]\n Alocando array de 100KB (provável LOH)...");
        var largeArray = new byte[100_000];
        Console.WriteLine("Objeto grande alocado.");
        Console.WriteLine($"Memória total Antes do Full GC: {GC.GetTotalMemory(false) / 1024} KB");

        Console.WriteLine("\nForçando Full GC para observar LOH...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine($"Memória total após Full GC: {GC.GetTotalMemory(false) / 1024} KB");
        Console.WriteLine($"Motivo: Geração do largeArray: {GC.GetGeneration(largeArray)}");
    }
}