using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
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