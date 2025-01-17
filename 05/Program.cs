Main();

void Main()
{
    Console.Clear();

    Console.WriteLine("Bem-vindo(a) ao Contador de Palavras!\n\nSinta-se a vontade para escrever uma frase ou apenas palavras aleatórias:");
    string frase = Console.ReadLine();

    if (frase == "") { Main(); }

    string[] palavras = frase
    .Split(
        new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries
    );

    Console.WriteLine($"A frase contém {palavras.Length} palavras.");

    Continuar();
}

void Continuar()
{
    Console.WriteLine("\nDeseja realizar outra contagem?\n1- Sim\n2- Não\n");
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