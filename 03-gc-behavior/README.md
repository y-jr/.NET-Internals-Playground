# 03 - GC Behavior (Gerações, Promoção e Finalizers)

Este experimento demonstra **como o Garbage Collector do .NET realmente se comporta em tempo de execução**, focando em **gerações (Gen0, Gen1, Gen2)**, **promoção de objetos**, **finalizers** e o impacto no uso de memória.

---

## Objetivo

* Entender o modelo **geracional** do GC
* Visualizar **promoção de objetos** entre gerações
* Compreender o custo de **finalizers**
* Observar por que a memória **nem sempre diminui após GC**
* Conectar teoria com comportamento real do runtime

---

## Conceitos Fundamentais

### Gerações do GC

* **Gen 0**: objetos de vida curta (mais coletada)
* **Gen 1**: geração intermediária
* **Gen 2**: objetos de vida longa

> A hipótese do GC é simples: *a maioria dos objetos morre jovem*.

---

### Finalizers

* Métodos `~Class()`
* Executados em uma **thread dedicada**
* Objetos com finalizer precisam de **duas coletas** para serem removidos
* Aumentam pressão em Gen2

---

## Experimento

No arquivo `Program.cs`:

1. Criamos objetos de curta duração (Gen0)
2. Mantemos referências vivas para forçar **promoção**
3. Criamos objetos com **finalizer**
4. Forçamos coletas e observamos gerações e memória

```csharp
CreateShortLivedObjects();
CreatePromotedObjects();
CreateFinalizableObjects();
```

---

## O que observar

* Objetos sendo promovidos para Gen1 e Gen2
* Objetos com finalizer sobrevivendo a uma coleta
* A necessidade de múltiplos `GC.Collect()`
* Diferença entre objetos finalizáveis e não finalizáveis

**Regra para sobrevivência de objetcos:**
                      |->SIM -> **Sobrevive**
                      |
   Está referencciado?|
                      |                                    |->NÃo -> **Sobrevive**
                      |->NÃO -> Sua Gen está sendo varrida?|
                                                           |->SIM -> **Morre**

---

## Impacto em Aplicações Reais

* Finalizers mal utilizados degradam performance
* Objetos de vida longa aumentam custo de Full GC
* Boa gestão de referências reduz pressão no GC

---

## Referências

* [Garbage Collection Fundamentals](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/)
* [Implementing Finalizers](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose)
* [GC Generations](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals)
