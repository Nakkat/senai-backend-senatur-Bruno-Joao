using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi
{
    public partial class Pacote
    {
        public int IdPacote { get; set; }
        public string NomePacote { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataIda { get; set; }
        public DateTime? DataVolta { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string NomeCidade { get; set; }
    }
}
