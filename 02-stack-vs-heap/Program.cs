using System;

struct PointStruct
{
    public int X;
    public int Y;
}

class PointClass
{
    public int X;
    public int Y;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Stack vs Heap ===\n");

        ValueTypeAssignment();
        ReferenceTypeAssignment();

        Console.WriteLine("\n--- Passagem como parâmetro ---\n");

        PassStructAsParameter();
        PassClassAsParameter();

        Console.WriteLine("\n--- Stack frame e escopo ---\n");
        var returnedStruct = CreateStruct();
        Console.WriteLine($"Struct retornado: X={returnedStruct.X}, Y={returnedStruct.Y}");

        Console.WriteLine("\nForçando GC...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine($"Memória total após GC: {GC.GetTotalMemory(false) / 1024} KB");

        Console.WriteLine("\nFim do experimento.");
        Console.ReadLine();
    }

    // 1. Atribuição direta
    static void ValueTypeAssignment()
    {
        Console.WriteLine("[Value Type - Atribuição]");
        PointStruct p1 = new PointStruct { X = 10, Y = 20 };
        PointStruct p2 = p1; // cópia por valor

        p2.X = 99;

        Console.WriteLine($"p1.X = {p1.X} (inalterado)");
        Console.WriteLine($"p2.X = {p2.X} (cópia independente)");
        Console.WriteLine($"ReferenceEquals(p1, p2) = {ReferenceEquals(p1, p2)}");
    }

    static void ReferenceTypeAssignment()
    {
        Console.WriteLine("\n[Reference Type - Atribuição]");
        PointClass p1 = new PointClass { X = 10, Y = 20 };
        PointClass p2 = p1; // cópia da referência

        p2.X = 99;

        Console.WriteLine($"p1.X = {p1.X} (alterado)");
        Console.WriteLine($"p2.X = {p2.X} (mesma referência)");
        Console.WriteLine($"ReferenceEquals(p1, p2) = {ReferenceEquals(p1, p2)}");
    }

    // 2. Passagem como parâmetro
    static void PassStructAsParameter()
    {
        PointStruct p = new PointStruct { X = 1, Y = 1 };
        ModifyStruct(p);
        Console.WriteLine($"Struct após método: X={p.X}, Y={p.Y} (inalterado)");
    }

    static void ModifyStruct(PointStruct p)
    {
        p.X = 50;
        p.Y = 50;
    }

    static void PassClassAsParameter()
    {
        PointClass p = new PointClass { X = 1, Y = 1 };
        ModifyClass(p);
        Console.WriteLine($"Class após método: X={p.X}, Y={p.Y} (alterado)");
    }

    static void ModifyClass(PointClass p)
    {
        p.X = 50;
        p.Y = 50;
    }

    // 3. Stack frame e retorno
    static PointStruct CreateStruct()
    {
        PointStruct p = new PointStruct { X = 7, Y = 7 };
        Console.WriteLine("Struct criado dentro do método (stack frame atual)");
        return p; // cópia para quem chamou
    }
}