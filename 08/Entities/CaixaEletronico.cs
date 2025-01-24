using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronicoComLogin
{
    public class CaixaEletronico
    {
        private List<Usuario> usuarios;   // Lista de usuários cadastrados
        private Usuario usuarioLogado;   // Usuário autenticado no momento

        public CaixaEletronico()
        {
            usuarios = new List<Usuario>
            {
                new Usuario("André", "andre76", "senha123", 1000.00m),
                new Usuario("Samuel", "samuander", "senha456", 2000.00m)
            };
        }

        public void Iniciar()
        {
            Console.Clear();

            while (true) // Permite múltiplos logins
            {
                if (Login())
                {
                    Menu();
                }
            }
        }

        private bool Login()
        {            
            Console.WriteLine("Bem-vindo ao Caixa Eletrônico");
            Console.Write("\nDigite seu login: ");
            string login = Console.ReadLine();
            Console.Write("\nDigite sua senha: ");
            string senha = Console.ReadLine();

            foreach (var usuario in usuarios)
            {
                if (usuario.Login == login && usuario.Senha == senha)
                {
                    usuarioLogado = usuario;
                    Console.WriteLine($"\nBem-vindo, {usuarioLogado.Nome}!");
                    return true;
                }
            }

            Console.WriteLine("\nLogin ou senha inválidos. Tente novamente.");
            return false;
        }

        private void Logout()
        {
            Console.WriteLine($"\nAté logo, {usuarioLogado.Nome}! Você foi desconectado.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Inicial...");
            Console.ReadKey();
            
            usuarioLogado = null; // Redefine o usuário logado
            Console.Clear();
        }

        private void Menu()
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("\n1- Consultar Saldo");
                Console.WriteLine("2- Sacar Dinheiro");
                Console.WriteLine("3- Depositar Dinheiro");
                Console.WriteLine("4- Logout");
                Console.WriteLine("0- Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ConsultarSaldo();
                        break;
                    case "2":
                        SacarDinheiro();
                        break;
                    case "3":
                        DepositarDinheiro();
                        break;
                    case "4":
                        Logout();   // Chama o método de logout
                        return;     // Sai do menu e volta para a tela de login
                    case "0":
                        sair = true;
                        Console.WriteLine("\nObrigado por usar o caixa eletrônico!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void ConsultarSaldo()
        {
            Console.WriteLine($"\nSeu saldo atual é: R$ {usuarioLogado.Saldo:F2}");
        }

        private void SacarDinheiro()
        {
            Console.Clear();

            Console.WriteLine($"\nSeu saldo atual é: R$ {usuarioLogado.Saldo:F2}");
            Console.Write("\nDigite o valor para saque: R$ ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
            {
                if (valorSaque > 0 && valorSaque <= usuarioLogado.Saldo)
                {
                    usuarioLogado.Saldo -= valorSaque;
                    Console.WriteLine($"Saque de R$ {valorSaque:F2} realizado com sucesso.");
                }
                else if (valorSaque > usuarioLogado.Saldo)
                {
                    Console.WriteLine("Saldo insuficiente para realizar o saque.");
                }
                else
                {
                    Console.WriteLine("Valor inválido para saque.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }

        private void DepositarDinheiro()
        {
            Console.Clear();

            Console.Write("\nDigite o valor para depósito: R$ ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
            {
                if (valorDeposito > 0)
                {
                    usuarioLogado.Saldo += valorDeposito;
                    Console.WriteLine($"Depósito de R$ {valorDeposito:F2} realizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Valor inválido para depósito.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }
    }
}