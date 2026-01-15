# 04 - JIT Benchmark (Cold vs Warm Execution)

Este experimento demonstra **como o JIT (Just-In-Time Compiler) afeta o desempenho** de aplicações .NET, comparando **execução fria (cold start)** com **execução aquecida (warm start)**.

O foco não é micro‑otimização, mas **entender o custo real da compilação JIT** e como isso impacta medições de performance.

---

## Objetivo

* Entender quando o **JIT compila métodos**
* Diferenciar **primeira execução** vs execuções subsequentes
* Mostrar por que benchmarks ingênuos são enganosos
* Conectar JIT com medições de tempo reais

---

## Conceitos Fundamentais

### JIT (Just-In-Time)

* Código C# é compilado para **IL**
* O JIT converte IL em **código nativo**
* A compilação ocorre **na primeira chamada do método**
* O código nativo é reutilizado nas chamadas seguintes

> “A primeira execução paga o custo do JIT.”

---

## Experimento

No arquivo `Program.cs`:

1. Medimos o tempo da **primeira execução** de um método
2. Medimos execuções subsequentes do mesmo método
3. Comparamos os tempos

```csharp
ColdRun();
WarmRun();
```

---

## O que observar

* Primeira execução significativamente mais lenta
* Execuções seguintes mais rápidas
* Diferença causada pela compilação JIT

---

## Importante sobre Benchmarks

* Benchmarks devem **aquecer o código** antes de medir
* Ferramentas como **BenchmarkDotNet** lidam com isso automaticamente
* Medições manuais servem para **entendimento conceitual**

---

## Referências

* [JIT Compiler Overview](https://learn.microsoft.com/en-us/dotnet/standard/managed-execution-process)
* [BenchmarkDotNet](https://benchmarkdotnet.org/)
