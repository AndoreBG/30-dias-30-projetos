Main();

void Celsius()
{
    Console.Clear();
    Console.WriteLine("Celsius\nDigite a temperatura em Celsius (Apenas o número):");
    string entrada = Console.ReadLine();
    double celsius;

    if (!double.TryParse(entrada, out celsius))
    {
        Celsius();
    }

    double fahrenheit = (celsius * 9 / 5) + 32;
    double kelvin = celsius + 273.15;

    Console.WriteLine($"\nTemperatura em Celsius:    {celsius:F2}ºC");
    Console.WriteLine($"Temperatura em Fahrenheit: {fahrenheit:F2}ºF");
    Console.WriteLine($"Temperatura em Kelvin:     {kelvin:F2}K");

    Continuar();
}

void Fahrenheit()
{
    Console.Clear();

    Console.WriteLine("Fahrenheit\nDigite a temperatura em Fahrenheit (Apenas o número):");
    string entrada = Console.ReadLine();
    double fahrenheit;

    if (!double.TryParse(entrada, out fahrenheit))
    {
        Fahrenheit();
    }

    double celsius = (fahrenheit - 32) * 5 / 9;
    double kelvin = celsius + 273.15;

    Console.WriteLine($"\nTemperatura em Fahrenheit: {fahrenheit:F2}ºF");
    Console.WriteLine($"Temperatura em Celsius:    {celsius:F2}ºC");
    Console.WriteLine($"Temperatura em Kelvin:     {kelvin:F2}K");

    Continuar();
}

void Kelvin()
{
    Console.Clear();
    Console.WriteLine("Kelvin\nDigite a temperatura em Kelvin (Apenas o número):");
    string entrada = Console.ReadLine();
    double kelvin;

    if (!double.TryParse(entrada, out kelvin))
    {
        Kelvin();
    }

    double celsius = kelvin - 273.15;
    double fahrenheit = (celsius * 9 / 5) + 32;

    Console.WriteLine($"\nTemperatura em Kelvin:     {kelvin:F2}K");
    Console.WriteLine($"Temperatura em Celsius:    {celsius:F2}ºC");
    Console.WriteLine($"Temperatura em Fahrenheit: {fahrenheit:F2}ºF");

    Continuar();
}

void Main()
{
    Console.Clear();

    Console.WriteLine("Bem-vindo(a) ao Conversor de Temperaturas\n");
    Console.WriteLine("Escolha a medida de temperatura inicial\n1- Celsius\n2- Fahrenheit\n3- Kelvin\n\n0- Sair");
    string escolha = Console.ReadLine();

    if (escolha == "") { Main(); }

    switch (escolha)
    {
        case "1":
            Celsius();
            break;
        case "2":
            Fahrenheit();
            break;
        case "3":
            Kelvin();
            break;
        case "0":
            Sair();
            break;
        default:
            Main();
            break;
    }
}

void Continuar()
{
    Console.WriteLine("\nDeseja realizar outra converção?\n1- Sim\n2- Não\n");
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