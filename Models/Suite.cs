using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public int Id { get; set; }
        public string TipoSuite { get; set; }
        public decimal ValorDiaria { get; set; }
        public int Capacidade { get; set; }

        
        public Suite(int id, string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Id = id;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
    }
}