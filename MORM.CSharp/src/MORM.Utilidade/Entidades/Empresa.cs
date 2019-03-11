using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Utilidade.Entidades
{
    public class Empresa : IEmpresa
    {
        public int Id_Empresa { get; set; }
        public string U_Version { get; set; }
        public int Cd_Operador { get; set; }
        public DateTime Dt_Cadastro { get; set; }
        public string Cd_Empresa { get; set; }
        public string Ds_Empresa { get; set; }
    }
}