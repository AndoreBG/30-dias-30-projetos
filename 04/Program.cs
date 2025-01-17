Main();

static List<int> ObterIntervalo()
    {
        Console.WriteLine("Digite o intervalo desejado no formato 'min,max' (exemplo: 1,6):");

        string[] partes = Console.ReadLine().Split(',');

        if (partes.Length != 2 ||
            !int.TryParse(partes[0], out int min) ||
            !int.TryParse(partes[1], out int max) ||
            min >= max || min < 1)
        {
            return null;
        }

        return new List<int> { min, max };
    }

void Main()
{
    Console.Clear();

    Console.WriteLine("Bem-vindo(a) ao Jogo da Adivinhação!\n");

    List<int> intervalo = ObterIntervalo();
    if (intervalo == null) { Main(); }

    Console.Clear();

    Console.WriteLine($"O intervalo escolhido foi: {intervalo[0]} a {intervalo[1]}.");

    Random random = new Random();
    int numeroSecreto = random.Next(intervalo[0], intervalo[1]);

    Console.WriteLine("Tente adivinhar o número secreto!");
    int tentativa;
    do
    {
        Console.Write("Sua tentativa: ");
        while (!int.TryParse(Console.ReadLine(), out tentativa))
        {
            Console.WriteLine("Por favor, insira um número válido!");
        }

        if (tentativa < numeroSecreto)
            Console.WriteLine("Muito baixo!");
        else if (tentativa > numeroSecreto)
            Console.WriteLine("Muito alto!");
        } while (tentativa != numeroSecreto);

    Console.WriteLine($"Parabéns! Você adivinhou o número secreto {numeroSecreto}.");

    Continuar();
}

void Continuar()
{
    Console.WriteLine("\nDeseja realizar outra adivinhação?\n1- Sim\n2- Não\n");
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