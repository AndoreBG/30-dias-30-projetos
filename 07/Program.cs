using System.Data.Common;
using Gerenciador;

class Program
{
    static List<Tarefa> tarefas = new List<Tarefa>();

    static void Main(string[] args)
    {
        Inicio();
    }

    static void Inicio()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Bem-vindo(a) ao Gerenciador de Tarefas!\n");

            Console.WriteLine("1- Ver Tarefas");
            Console.WriteLine("2- Adicionar Tarefa");
            Console.WriteLine("3- Editar Tarefa");
            Console.WriteLine("4- Excluir Tarefa");
            Console.WriteLine("0- Sair\n");

            Console.WriteLine("Escolha uma opção:");
            var op = Console.ReadLine();

            switch (op) 
            {
                case "1":
                    VerTarefas();
                    break;
                case "2":
                    AdicionarTarefa();                
                    break;
                case "3":
                    EditarTarefa();
                    break;
                case "4":
                    ExcluirTarefa();
                    break;
                case "0":
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

    static void VerTarefas()
    {
        Console.Clear();

        Console.WriteLine("Lista de Tarefas\n");
        if (tarefas.Count == 0) 
        {
            Console.WriteLine("Nenhuma tarefa encontrada\n");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        else 
        {
            var tarefasOrdenadas = tarefas.OrderBy(t => t.Horario).ToList();

            foreach (Tarefa tarefa in tarefasOrdenadas)
            {
                Console.WriteLine(tarefa);
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void AdicionarTarefa()
    {
        Console.Clear();

        Console.WriteLine("Adicionar Tarefa\n");
        Console.WriteLine("Escreva o horário (formato hh:mm 24H): ");
        string horario = Console.ReadLine();

        Console.WriteLine("Escreva o titulo da tarefa: ");
        string tarefa = Console.ReadLine();

        Console.WriteLine("Escreva a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        if (horario == "" || tarefa == "")
        {
            Console.WriteLine("Horario ou titulo vazio!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            AdicionarTarefa();
        }

        if (descricao == "") { descricao = "(vazio)"; }

        tarefas.Add(new Tarefa { Horario = horario, Titulo = tarefa, Descricao = descricao});
        Console.WriteLine("\nTarefa adicionada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void EditarTarefa()
    {
        Console.Clear();
        Console.WriteLine("Editar Tarefa\n");
        Console.Write("Digite o titulo (ou as primeiras letras) da tarefa: ");
        string tarefaBusca = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(tarefaBusca))
        {
            Console.WriteLine("\nPor favor, insira uma tarefa.");
            Console.ReadKey();
            return;
        }

        var tarefaEncontrados = tarefas.Where(t => t.Titulo.StartsWith(tarefaBusca, StringComparison.OrdinalIgnoreCase)).ToList();

        if (tarefaEncontrados.Count == 1)
        {
            var tarefa = tarefaEncontrados[0];
            Console.WriteLine($"\nTarefa encontrada: {tarefa}");
            Console.WriteLine("\nDigite as novas informações ou pressione Enter para manter as atuais.");

            Console.Write("Novo horario: ");
            string novoHorario = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoHorario)) tarefa.Horario = novoHorario;

            Console.Write("\nNovo título: ");
            string novoTitulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoTitulo)) tarefa.Titulo = novoTitulo;

            Console.Write("\nNova descrição: ");
            string novaDescricao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDescricao)) tarefa.Descricao = novaDescricao;

            Console.WriteLine("\nTarefa atualizada com sucesso!");
        }
        else if (tarefaEncontrados.Count > 1)
        {
            Console.WriteLine("Mais de uma tarefa encontrada. Selecione o número correspondente:");
            for (int i = 0; i < tarefaEncontrados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tarefaEncontrados[i]}");
            }

            Console.Write("Escolha o número da tarefa a editar: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= tarefaEncontrados.Count)
            {
                var tarefa = tarefaEncontrados[escolha - 1];
                Console.WriteLine($"Editando: {tarefa}");
                Console.WriteLine("Digite as novas informações ou pressione Enter para manter as atuais.");

                Console.Write("Novo horario: ");
                string novoHorario = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoHorario)) tarefa.Horario = novoHorario;

                Console.Write("\nNovo título: ");
                string novoTitulo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoTitulo)) tarefa.Titulo = novoTitulo;

                Console.Write("\nNova descrição: ");
                string novaDescricao = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaDescricao)) tarefa.Descricao = novaDescricao;

                Console.WriteLine("\nTarefa atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nOpção inválida. Voltando ao menu.");
            }
        }
        else
        {
            Console.WriteLine("\nNenhuma tarefa encontrada.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void ExcluirTarefa()
    {
        Console.Clear();
        Console.WriteLine("=== Excluir Contato ===\n");
        Console.Write("Digite o nome (ou as primeiras letras) do contato: ");
        string tarefaBusca = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(tarefaBusca))
        {
            Console.WriteLine("\nPor favor, insira um nome.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Buscar contatos que começam com o nome digitado
        var tarefasEncontrados = tarefas.Where(c => c.Titulo.StartsWith(tarefaBusca, StringComparison.OrdinalIgnoreCase)).ToList();

        if (tarefasEncontrados.Count == 1)
        {
            var tarefa = tarefasEncontrados[0];
            Console.WriteLine($"\nTarefa encontrada: {tarefa}");
            Console.Write("\nTem certeza que deseja excluir? (S/N): ");
            var resposta = Console.ReadLine();
            if (resposta?.ToUpper() == "S")
            {
                tarefas.Remove(tarefa);
                Console.WriteLine("\nTarefa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("\nExclusão cancelada.");
            }
        }
        else if (tarefasEncontrados.Count > 1)
        {
            Console.WriteLine("\nMais de uma tarefa encontrada. Selecione o número correspondente:");
            for (int i = 0; i < tarefasEncontrados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tarefasEncontrados[i]}");
            }

            Console.Write("\nEscolha o número da tarefa a excluir: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= tarefasEncontrados.Count)
            {
                var tarefa = tarefasEncontrados[escolha - 1];
                Console.WriteLine($"\nContato encontrado: {tarefa}");
                Console.Write("\nTem certeza que deseja excluir? (S/N): ");
                var resposta = Console.ReadLine();
                if (resposta?.ToUpper() == "S")
                {
                    tarefas.Remove(tarefa);
                    Console.WriteLine("\nTarefa excluída com sucesso!");
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
            Console.WriteLine("\nNenhuma tarefa encontrada.");
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