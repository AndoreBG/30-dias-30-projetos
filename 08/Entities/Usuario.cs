using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronicoComLogin
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }

        public Usuario(string nome, string login, string senha, decimal saldo)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Saldo = saldo;
        }
    }
}