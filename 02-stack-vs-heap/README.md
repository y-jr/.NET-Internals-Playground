# 02 - Stack vs Heap

Este experimento demonstra, de forma prática, **as diferenças entre Stack e Heap no .NET**, mostrando como tipos de valor e tipos de referência são alocados, como o tempo de vida dos dados funciona e qual o impacto no desempenho e no Garbage Collector.

---

## Objetivo

* Entender o papel da **Stack** e do **Heap** na execução de um programa C#
* Visualizar a alocação de **value types** e **reference types**
* Observar tempo de vida e escopo das variáveis
* Conectar decisões de design com impacto em performance e GC

---

## Conceitos Fundamentais

### Stack

* Memória **automática**
* Alocação e liberação rápidas (LIFO)
* Armazena:

  * Variáveis locais
  * Parâmetros de métodos
  * Referências para objetos no Heap
* Não é gerenciada diretamente pelo GC

### Heap

* Memória **dinâmica**
* Armazena objetos e arrays
* Gerenciada pelo **Garbage Collector**
* Tempo de vida baseado em referências

---

## Experimento

No arquivo `Program.cs`:

1. Criamos **structs (value types)** para observar alocação na Stack.
2. Criamos **classes (reference types)** para observar alocação no Heap.
3. Demonstramos cópia por valor vs cópia por referência.
4. Observamos o impacto no GC.

```csharp
CreateValueType();
CreateReferenceType();
```

---

## O que observar

* Diferença de comportamento ao passar structs e classes como parâmetros
* Quando o GC é acionado
* Como referências apontam para objetos no Heap
* Por que objetos na Stack não sobrevivem ao escopo do método

---

## Impacto em Performance

* Stack é extremamente rápida
* Heap é mais flexível, porém mais custosa
* Uso excessivo de Heap aumenta pressão no GC

> Design eficiente equilibra segurança, clareza e performance.

---

## Próximos Passos

* Comparar structs grandes vs pequenos
* Introduzir `Span<T>` e `ref struct`
* Medir impacto com benchmark

---

## Referências

* [Microsoft Docs: Stack and Heap](https://learn.microsoft.com/en-us/dotnet/standard/managed-memory)
* [Value Types vs Reference Types](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/)
