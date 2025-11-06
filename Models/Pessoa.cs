using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string? Sobrenome { get; set; }

        public Pessoa(string nome, string? sobrenome = null)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public string NomeCompleto => $"{Nome} {Sobrenome}".Trim();
    }
}