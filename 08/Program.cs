using System;
using CaixaEletronicoComLogin;

internal class Program
{
    private static void Main(string[] args)
    {
        CaixaEletronico caixa = new CaixaEletronico();
        caixa.Iniciar();
    }
}