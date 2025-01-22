using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador
{
    public class Tarefa
    {
        public string Horario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return $"Horario: {Horario}, Tarefa: {Titulo}, \nDescrição: {Descricao}";
        }
    }
}