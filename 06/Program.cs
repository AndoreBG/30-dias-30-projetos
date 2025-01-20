using System.Collections;
using Agenda;

class Program
{
    static List<Contato> contatos = new List<Contato>();

    static void Main(string[] args)
    {
        Inicio();
    }
    static void Inicio()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== Agenda de Contatos ===\n");

            Console.WriteLine("1- Adicionar contato");
            Console.WriteLine("2- Listar contatos");
            Console.WriteLine("3- Buscar contato");
            Console.WriteLine("4- Editar contato");
            Console.WriteLine("5- Excluir contato");
            Console.WriteLine("6. Sair\n");

            Console.WriteLine("Escolha uma opção:");
            var op = Console.ReadLine();

            // if (op == "") { Inicio(); } // caso o usuário não digite nada

            switch (op) 
            {
                case "1":
                    AdicionarContato();
                    break;
                case "2":
                    ListarContatos();                
                    break;
                case "3":
                    BuscarContato();
                    break;
                case "4":
                    EditarContato();
                    break;
                case "5":
                    ExcluirContato();
                    break;
                case "6":
                    Sair();
                    break;
                default:
                    Console.WriteLine("\nOpção inválida!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AdicionarContato()
    {
        Console.Clear();

        Console.WriteLine("=== Adicionar contato ===\n");
        Console.WriteLine("Digite o nome (sem acentuação): ");
        string nome = Console.ReadLine();

        Console.WriteLine("\nDigite o telefone: ");
        string telefone = Console.ReadLine();

        Console.WriteLine("\nDigite o email (caso não tenha, deixe vazio): ");
        string email = Console.ReadLine();

        if (nome == "" || telefone == "")
        {
            Console.WriteLine("\nNome ou telefone vazio!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            AdicionarContato();
        }

        if (email == "") { email = "(vazio)"; }

        contatos.Add(new Contato { Nome = nome, Telefone = telefone, Email = email });
        Console.WriteLine("\nContato adicionado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarContatos()
    {
        Console.Clear();

        Console.WriteLine("=== Lista de Contatos ===\n");
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Inicio();
        }
        else
        {
            var contatosOrdenados = contatos.OrderBy(c => c.Nome).ToList();

            foreach (Contato contato in contatosOrdenados)
            {
                Console.WriteLine(contato);
            }
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void BuscarContato()
    {
        Console.Clear();

        Console.WriteLine("=== Buscar de Contato ===\n");

        Console.WriteLine("Escreva o nome do contato: ");
        string nomeBusca = Console.ReadLine();

        var resultados = contatos.Where(c => c.Nome.StartsWith(nomeBusca, StringComparison.OrdinalIgnoreCase)).OrderBy(c => c.Nome).ToList();

        if (resultados.Any())
        {
            Console.WriteLine("\nContatos encontrados: \n");
            foreach (var contato in resultados)
            {
                Console.WriteLine(contato);
            }
        }
        else
        {
            Console.WriteLine("Contato não encontrado"); 
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void EditarContato()
    {
        Console.Clear();
        Console.WriteLine("=== Editar Contato ===\n");
        Console.Write("Digite o nome (ou as primeiras letras) do contato: ");
        string nomeBusca = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeBusca))
        {
            Console.WriteLine("\nPor favor, insira um nome.");
            Console.ReadKey();
            return;
        }

        var contatosEncontrados = contatos.Where(c => c.Nome.StartsWith(nomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

        if (contatosEncontrados.Count == 1)
        {
            var contato = contatosEncontrados[0];
            Console.WriteLine($"\nContato encontrado: {contato}");
            Console.WriteLine("\nDigite as novas informações ou pressione Enter para manter as atuais.");

            Console.Write("Novo Nome: ");
            string novoNome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome)) contato.Nome = novoNome;

            Console.Write("\nNovo Telefone: ");
            string novoTelefone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoTelefone)) contato.Telefone = novoTelefone;

            Console.Write("\nNovo Email: ");
            string novoEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoEmail)) contato.Email = novoEmail;

            Console.WriteLine("\nContato atualizado com sucesso!");
        }
        else if (contatosEncontrados.Count > 1)
        {
            Console.WriteLine("Mais de um contato encontrado. Selecione o número correspondente:");
            for (int i = 0; i < contatosEncontrados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contatosEncontrados[i]}");
            }

            Console.Write("Escolha o número do contato a editar: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= contatosEncontrados.Count)
            {
                var contato = contatosEncontrados[escolha - 1];
                Console.WriteLine($"Editando: {contato}");
                Console.WriteLine("Digite as novas informações ou pressione Enter para manter as atuais.");

                Console.Write("Novo Nome: ");
                string novoNome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoNome)) contato.Nome = novoNome;

                Console.Write("Novo Telefone: ");
                string novoTelefone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoTelefone)) contato.Telefone = novoTelefone;

                Console.Write("Novo Email: ");
                string novoEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoEmail)) contato.Email = novoEmail;

                Console.WriteLine("\nContato atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nOpção inválida. Voltando ao menu.");
            }
        }
        else
        {
            Console.WriteLine("\nNenhum contato encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void ExcluirContato()
    {
        Console.Clear();
        Console.WriteLine("=== Excluir Contato ===\n");
        Console.Write("Digite o nome (ou as primeiras letras) do contato: ");
        string nomeBusca = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeBusca))
        {
            Console.WriteLine("\nPor favor, insira um nome.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Buscar contatos que começam com o nome digitado
        var contatosEncontrados = contatos.Where(c => c.Nome.StartsWith(nomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

        if (contatosEncontrados.Count == 1)
        {
            var contato = contatosEncontrados[0];
            Console.WriteLine($"\nContato encontrado: {contato}");
            Console.Write("\nTem certeza que deseja excluir? (S/N): ");
            var resposta = Console.ReadLine();
            if (resposta?.ToUpper() == "S")
            {
                contatos.Remove(contato);
                Console.WriteLine("\nContato excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("\nExclusão cancelada.");
            }
        }
        else if (contatosEncontrados.Count > 1)
        {
            Console.WriteLine("\nMais de um contato encontrado. Selecione o número correspondente:");
            for (int i = 0; i < contatosEncontrados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contatosEncontrados[i]}");
            }

            Console.Write("\nEscolha o número do contato a excluir: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= contatosEncontrados.Count)
            {
                var contato = contatosEncontrados[escolha - 1];
                Console.WriteLine($"\nContato encontrado: {contato}");
                Console.Write("\nTem certeza que deseja excluir? (S/N): ");
                var resposta = Console.ReadLine();
                if (resposta?.ToUpper() == "S")
                {
                    contatos.Remove(contato);
                    Console.WriteLine("\nContato excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nExclusão cancelada.");
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
            }
        }
        else
        {
            Console.WriteLine("\nNenhum contato encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void Sair()
    {
        Console.Clear();

        Console.WriteLine("Saindo...");
        Environment.Exit(0);
    }
}
