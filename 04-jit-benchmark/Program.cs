using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== JIT Benchmark with Visualization ===\n");

        // Armazenar resultados
        long[] ticks = new long[4];

        ticks[0] = Measure("Cold Run", () => Workload());
        ticks[1] = Measure("Warm Run 1", () => Workload());
        ticks[2] = Measure("Warm Run 2", () => Workload());
        ticks[3] = Measure("Warm Run 3", () => Workload());

        Console.WriteLine("\nResumo das execuções (ticks):");
        for (int i = 0; i < ticks.Length; i++)
            Console.WriteLine($"Execução {i + 1}: {ticks[i]} ticks");

        Console.WriteLine("\nVisualização simples (| = 5000 ticks):");
        foreach (var t in ticks)
        {
            int bars = (int)(t / 5000);
            Console.WriteLine("|" + new string('█', bars));
        }

        Console.WriteLine("\nFim do experimento.");
        Console.ReadLine();
    }

    static long Measure(string label, Action action)
    {
        var sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        Console.WriteLine($"{label}: {sw.ElapsedTicks} ticks");
        return sw.ElapsedTicks;
    }

    static void Workload()
    {
        long sum = 0;
        for (int i = 0; i < 10_000_000; i++)
        {
            sum += i;
        }
    }
}