using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Utilidade.Entidades
{
    public class Terminal : ITerminal
    {
        public int Id_Terminal { get; set; }
        public string U_Version { get; set; }
        public int Cd_Operador { get; set; }
        public DateTime Dt_Cadastro { get; set; }
        public string Cd_Terminal { get; set; }
        public string Ds_Terminal { get; set; }
    }
}