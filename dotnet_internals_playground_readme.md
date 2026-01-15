# .NET Internals Playground

Criei este repositório para partilhar algum do meu conhecimento sobre os principais componentes internos do .NET:

 - CLR (Common Language Runtime)
 - JIT (Just-In-Time Compiler)
 - Garbage Collector (GC)
 - Stack vs Heap
 - Benchmarking simples e correto

O foco aqui NÃO É COMPLEXIDADE DE CÓDIGO, e sim CLAREZA CONCEITUAL, observação do runtime e tomada de decisão baseada em medição.

---

## 🎯 Objetivo

Mostrar que eu:
- Entendo **como o código C# é executado internamente**
- Sei **identificar impacto de alocação e GC**
- Sei **explicar Stack vs Heap sem simplificações erradas**
- Sei **medir performance corretamente** usando ferramentas adequadas

Este repositório pode ser lido como um **laboratório de experimentos do CLR**.

---

## 🧱 Estrutura do Repositório

```
dotnet-internals-playground/
│
├── 01-clr-jit-gc/
│   ├── Program.cs
│   └── README.md
│
├── 02-stack-vs-heap/
│   ├── Program.cs
│   └── README.md
│
├── 03-gc-and-loh/
│   ├── Program.cs
│   └── README.md
│
├── 04-benchmarks/
│   ├── AllocationBenchmarks.cs
│   └── README.md
│
└── README.md
```

Cada pasta contém:
- Código simples e intencional
- Um README explicando **o que observar e por quê**

---

## 1️⃣ CLR, JIT e Garbage Collector

📁 **01-clr-jit-gc**

### O que este experimento demonstra

- O papel do **CLR** como ambiente de execução
- Quando o **JIT compila métodos**
- Como o **GC atua em alocações pequenas**

### Ideia do experimento

- Criar muitas alocações pequenas
- Observar o comportamento do GC
- Entender que o código é compilado **em runtime**, não antes

### Conceitos demonstrados

- IL → Código nativo via JIT
- GC Gen 0 como primeira linha de coleta
- Diferença entre tempo de execução e tempo de compilação

📌 **Importante:**
O código é simples de propósito. O valor está na análise do comportamento do runtime.

---

## 2️⃣ Stack vs Heap

📁 **02-stack-vs-heap**

### Objetivo

Demonstrar claramente:
- O que vai para a **stack**
- O que vai para o **heap**
- O que o GC realmente gerencia

### Conceitos-chave

- `struct` não significa automaticamente stack
- `class` sempre vive no heap
- A stack armazena **referências**, não objetos

### O que observar

- Tempo de vida das variáveis
- Escopo de execução
- Diferença entre valor e referência

Este experimento elimina mitos comuns sobre memória em C#.

---

## 3️⃣ Garbage Collector e LOH (Large Object Heap)

📁 **03-gc-and-loh**

### Por que este experimento é importante

O **LOH é uma das maiores causas de problemas de performance em aplicações .NET reais**.

### O que é demonstrado

- Objetos grandes (≥ ~85 KB) indo direto para o LOH
- Promoção automática para Gen 2
- Por que o LOH fragmenta
- Por que Full GC é caro

### Cenários reais relacionados

- Upload / download de arquivos
- Serialização de JSON grandes
- Buffers de rede
- Processamento de imagens

### Conclusão prática

Alocar grandes objetos sem estratégia leva a:
- Fragmentação
- Pausas longas de GC
- Crescimento contínuo de memória

---

## 4️⃣ Benchmark Simples e Correto

📁 **04-benchmarks**

### Ferramenta usada

- **BenchmarkDotNet**

Motivo:
- Controle de warm-up
- Isolamento de processo
- Medição real de alocações
- Estatística confiável

### O que é comparado

- Alocação direta de arrays grandes
- Reutilização via `ArrayPool<T>`

### Métricas analisadas

- Tempo médio
- Memória alocada
- Coletas de GC
- Impacto no LOH

📌 O benchmark não serve para “micro-otimização”, e sim para **validar decisões técnicas**.

---

## 🧠 Lições Importantes Demonstradas

- GC **gerencia memória**, não recursos
- Stack é sobre **execução**, heap é sobre **tempo de vida**
- JIT permite otimizações específicas da máquina
- LOH exige cuidado explícito
- Performance sem medição é suposição

---

## 🚀 Como executar os exemplos

Pré-requisitos:
- .NET 6+ ou superior

Executar um experimento:

```bash
dotnet run
```

Executar benchmarks:

```bash
dotnet run -c Release
```

> ⚠️ Benchmarks devem sempre rodar em **Release** e sem debugger.

---

## 📌 Observação Final

Este repositório não é um tutorial introdutório.

Ele foi criado para **demonstrar entendimento profundo do runtime .NET**, algo essencial para:
- Backends de alta performance
- Serviços de longa duração
- Sistemas críticos

---

## 👤 Autor

**Adilson Muieba**  
Desenvolvedor .NET focado em arquitetura, performance e runtime internals.

---

> “Código rápido não é o que roda mais rápido — é o que aloca menos e o runtime entende melhor.”

