# 01 - CLR, JIT e Garbage Collector

Este experimento tem como objetivo demonstrar, de forma prática, **como o CLR executa código C#**, **como o JIT compila métodos em tempo de execução** e **como o Garbage Collector gerencia memória**.

---

## Objetivo

* Entender a função do **CLR** como runtime do .NET
* Observar a ação do **JIT** durante a execução de métodos
* Visualizar a coleta de memória pelo **GC** em objetos de curta e longa duração
* Conectar teoria com código executável simples

---

## Experimento

No arquivo `Program.cs`:

1. Criamos muitas alocações de objetos pequenos.
2. Observamos a diferença entre métodos que são compilados **em tempo de execução** e os que são executados.
3. Examinamos o comportamento do GC em Gen 0, Gen 1 e Gen 2.

```csharp
// Exemplo simplificado
Console.WriteLine("Início do experimento");
for (int i = 0; i < 1_000_000; i++)
{
    var obj = new object();
}
Console.WriteLine("Fim do experimento");
```

> Observação: O valor do experimento está na análise do comportamento do runtime e não na complexidade do código.

---

## Conceitos Demonstrados

| Conceito | O que é demonstrado                                                                    |
| -------- | -------------------------------------------------------------------------------------- |
| CLR      | Ambiente de execução, gerenciamento de memória e execução do código IL                 |
| JIT      | Compilação de IL para código nativo durante a execução, otimizações específicas de CPU |
| GC       | Coleta de objetos não referenciados, promoção entre gerações, Full GC                  |

---

## O que observar

* Quando o JIT compila métodos
* Promoção de objetos no GC
* Como objetos de curta duração são coletados rapidamente
* Diferença entre Gen 0, Gen 1 e Gen 2

---

## Próximos Passos

* Comparar comportamento com objetos grandes (LOH)
* Medir tempo de execução com benchmark simples
* Observar logs de coleta de GC usando `GC.Collect()` e `GC.GetGeneration(obj)`

---

## Referências

* [Microsoft Docs: CLR Overview](https://learn.microsoft.com/en-us/dotnet/standard/clr)
* [JIT Compiler](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals)
* [Garbage Collection Fundamentals](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/)
