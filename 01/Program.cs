using System.ComponentModel.DataAnnotations;

Inicio();

void Adicao()
{
    Console.Clear();

    double nAtual = 0;

    Console.WriteLine("Adição\nEscreva o número de adições: ");
    int op = Convert.ToInt32(Console.ReadLine());
    
    if (op <= 0) { Adicao(); } // Anti-engraçadinhos :)

    for (int i = 0; i < op; i++)
    {
        Console.WriteLine($"\nEscreva o {i + 1}º número: ");
        nAtual = nAtual + Convert.ToDouble(Console.ReadLine());
    }

    Console.WriteLine($"\nO resultado da adição é {nAtual}");
    
    Continuar();
}

void Subtracao()
{
    Console.Clear();
    
    double nAtual = 0;
    
    Console.WriteLine("Subtração\nEscreva o número de subtrações: ");
    int op = Convert.ToInt32(Console.ReadLine());

    if (op <= 0) { Subtracao(); } // Anti-engraçadinhos :)

    Console.WriteLine("\nEscreva o 1º número: ");
    nAtual = Convert.ToDouble(Console.ReadLine());

    for (int i = 1; i < op; i++)
    {
        Console.WriteLine($"Escreva o {i + 1}º número: ");
        double nSub = Convert.ToDouble(Console.ReadLine());
        nAtual -= nSub;
    }

    Console.WriteLine($"\nO resultado da subtração é {nAtual}");

    Continuar();
}

void Multiplicacao()
{
    Console.Clear();
    
    double nAtual = 0;

    Console.WriteLine("Multiplicação\nEscreva o número de multiplicações: ");
    int op = Convert.ToInt32(Console.ReadLine());
    
    if (op <= 0) { Multiplicacao(); } // Anti-engraçadinhos :)

    Console.WriteLine("\nEscreva o 1º número: ");
    nAtual = Convert.ToDouble(Console.ReadLine());

    for (int i = 1; i < op; i++)
    {
        Console.WriteLine($"\nEscreva o {i + 1}º número: ");
        double nMult = Convert.ToDouble(Console.ReadLine());
        nAtual = nAtual * nMult;
    }

    Console.WriteLine($"\nO resultado da multiplicação é {nAtual}");

    Continuar();
}

void Divisao()
{
    Console.Clear();
    
    double nAtual = 0;

    Console.WriteLine("Divisão\nEscreva o número de divisões: ");
    int op = Convert.ToInt32(Console.ReadLine());
    
    if (op < 0) { Divisao(); } // Anti-engraçadinhos :)

    Console.WriteLine("\nEscreva o 1º número: ");
    nAtual = Convert.ToDouble(Console.ReadLine());

    if (nAtual == 0) { Console.Beep(); Divisao(); }

    for (int i = 1; i < op; i++)
    {
        Console.WriteLine($"\nEscreva o {i + 1}º número: ");
        double nDiv = Convert.ToDouble(Console.ReadLine());
            if (nDiv == 0) { Console.Beep(); Divisao(); }
        nAtual = nAtual / nDiv;
    }

    Console.WriteLine($"\nO resultado da divisão é {nAtual}");

    Continuar();
}

void Potencia()
{
    Console.Clear();

    double nAtual = 0;

    Console.WriteLine("\nPotenciação\nEscreva a base: ");
    double b = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o número de expoentes: ");
    int op = Convert.ToInt32(Console.ReadLine());

    if (op <= 0) { Potencia(); }
    else if (op == 1)
    {
        Console.WriteLine($"\nEscreva o expoente: ");
        double nPot = Convert.ToDouble(Console.ReadLine());
        nAtual = Math.Pow(b, nPot);
    }
    else
    {
        Console.WriteLine($"\nEscreva o 1º expoente: ");
        nAtual = Math.Pow(b, Convert.ToDouble(Console.ReadLine()));

        for(int i = 1; i < op; i++)
        {
            Console.WriteLine($"\nEscreva o {i + 1}º expoente: ");
            double nPot = Convert.ToDouble(Console.ReadLine());
            nAtual = Math.Pow(nAtual, nPot);
        }
    }

    if (nAtual >= double.MaxValue)
    {
        Estorou();
    }
    Console.WriteLine($"O resultado da exponenciação é {nAtual}");

    Continuar();
}

void Raiz()
{
    Console.Clear();
    
    Console.WriteLine("\nRaiz\nEscreva o radicando: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    if (n1 <= 0) { Raiz(); }	

    Console.WriteLine("\nEscreva o índice: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da raiz de índice {n2} e base {n1} é: {Math.Pow(n1, 1 / n2)}");

    Continuar();
}

void Fatorial()
{
    Console.Clear();

    long nAtual = 1; // Usa 'long' para suportar números grandes

    Console.WriteLine("Fatorial\nEscreva o número: ");
    int n = Convert.ToInt32(Console.ReadLine());

    if (n < 0) { Fatorial(); }
    for (int i = 1; i <= n; i++)
    {
        nAtual *= i;
    }

    Console.WriteLine($"\nO resultado da fatorial é {nAtual}");
    
    Continuar();
}

void Inicio()
{
    Console.Clear();

    Console.WriteLine("Bem-vindo(a) à Calculadora Básica!\n");
    Console.WriteLine("1- Adição                5- Potenciação");
    Console.WriteLine("2- Subtração             6- Raiz");
    Console.WriteLine("3- Multiplicação         7- Fatorial");
    Console.WriteLine("4- Divisão");
    Console.WriteLine("\n0- Sair");

    Console.WriteLine("\nSelecione o modo de operação:");
    string opcao = Console.ReadLine();

    switch(opcao)
    {
        case "1":
            Adicao();
            break;
        case "2":
            Subtracao();
            break;
        case "3":
            Multiplicacao();
            break;
        case "4":
            Divisao();
            break;
        case "5":
            Potencia();
            break;
        case "6":
            Raiz();
            break;
        case "7":
            Fatorial();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            Environment.Exit(0);
            break;
        default: // Anti-engraçadinhos :)
            if (opcao == null)
                Inicio();
            Inicio();
            break;
    }
}

void Continuar()
{
    Console.WriteLine("\nDeseja realizar outra operação?\n1- Sim\n2- Não");
    string escolha = Console.ReadLine();
    switch (escolha)
    {
        case "1":
            Inicio();
            break;
        case "2":
            Sair();
            break;
        default: // Anti-engraçadinhos :)
            Continuar();
            break;
    }
}

void Sair()
{
    Console.Clear();

    Console.WriteLine("Saindo...");
    Environment.Exit(0);
}

void Estorou()
{
    Console.WriteLine("\nResultado passou do limite máximo suportado!\nDeseja tentar novamente?\n1- Sim\n2- Não");
    string escolha = Console.ReadLine();
    switch (escolha)
    {
        case "1":
            Potencia();
            break;
        case "2":
            Inicio();
            break;
        default: // Anti-engraçadinhos :)
            Estorou();
            break;
    }
}