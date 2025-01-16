Main();

void Main()
{
    int minNumber;
    int maxNumber;
    int qtdGen;

    Console.Clear();

    Console.WriteLine("Bem-vindo(a) ao Gerador Aleatório de Números!");
        Console.WriteLine("\nDigite o menor número possível:");
        string entradaMin = Console.ReadLine();

        if (!int.TryParse(entradaMin, out minNumber)) { Main(); }
        Console.Clear();
    
    EntradaMax:
        Console.WriteLine("\nDigite o maior número possível: ");
        string entradaMax = Console.ReadLine();
        
        Console.Clear();
        if (!int.TryParse(entradaMax, out maxNumber)) { goto EntradaMax; }

    EntradaGen:
        Console.WriteLine("\nDigite a quantidade de números gerados:");
        string entradaGen = Console.ReadLine();
        
        Console.Clear();
        if (!int.TryParse(entradaGen, out qtdGen)) { goto EntradaGen; }

    Console.WriteLine($"Gerando {qtdGen} números aleatórios entre {minNumber.ToString()} e {maxNumber.ToString()}\n");

    for (int i = 0; i < qtdGen; i++)
    {
        Random rnd = new Random();
        Console.WriteLine($"{i + 1}º- {rnd.Next(minNumber, maxNumber)}");   
    }

    Continuar();
}

void Continuar()
{
    Console.WriteLine("\nDeseja gerar novos números?\n1- Sim\n2- Não\n");
    string escolha = Console.ReadLine();

    if (escolha == "") { Continuar(); }
    else if (escolha == "1") { Main(); }
    else if (escolha == "2") { Sair(); }
    else { Continuar(); }
}

void Sair()
{
    Console.Clear();

    Console.WriteLine("Saindo...");
    Environment.Exit(0);
}