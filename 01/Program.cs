Inicio();

void Adicao()
{
    Console.WriteLine("\nAdição\nEscreva o primeiro número: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o segundo número: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da adição {n1} + {n2} é: {n1 + n2}");

    Continuar();
}

void Subtracao()
{
    Console.WriteLine("\nSubtração\nEscreva o primeiro número: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o segundo número: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da subtração {n1} - {n2} é: {n1 - n2}");

    Continuar();
}

void Multiplicacao()
{
    Console.WriteLine("\nMultiplicação\nEscreva o multiplicando: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o multiplicador: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da multiplicação {n1} x {n2} é: {n1 * n2}");

    Continuar();
}

void Divisao()
{
    Console.WriteLine("\nDivisão\nEscreva o dividendo: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o divisor: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da divisão {n1} / {n2} é: {n1 / n2}");

    Continuar();
}

void Potencia()
{
    Console.WriteLine("\nPotenciação\nEscreva a base: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o expoente: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da pontenciação {n1} ^ {n2} é: {Math.Pow(n1, n2)}");

    Continuar();
}

void Raiz()
{
    Console.WriteLine("\nRaiz\nEscreva o radicando: ");
    double n1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("\nEscreva o índice: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO resultado da raiz de índice {n2} e base {n1} é: {Math.Pow(n1, 1 / n2)}");

    Continuar();
}

void Inicio()
{
    Console.Clear();

    Console.WriteLine("Bem-vindo(a) à Calculadora Básica!\n");
    Console.WriteLine("1- Adição                5- Potenciação");
    Console.WriteLine("2- Subtração             6- Raiz");
    Console.WriteLine("3- Multiplicação");
    Console.WriteLine("4- Divisão");
    Console.WriteLine("0- Sair");

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
        case "0":
            Console.WriteLine("Saindo...");
            Environment.Exit(0);
            break;
        default:
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
    if (escolha == "1")
        Inicio();
    else
        Sair();
}

void Sair()
{
    Console.WriteLine("Saindo...");
    Environment.Exit(0);
}