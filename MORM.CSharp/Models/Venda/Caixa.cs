using MORM.CSharp.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("CAIXA")]
    public class Caixa : CollectionItem
    {
        [Campo("ID_CAIXA", CampoTipo.Key)]
        public int Id_Caixa { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_EMPRESA", CampoTipo.Req)]
        public int Id_Empresa { get; set; }
        [Campo("ID_TERMINAL", CampoTipo.Req)]
        public int Id_Terminal { get; set; }
        [Campo("DT_ABERTURA", CampoTipo.Req)]
        public DateTime Dt_Abertura { get; set; }
        [Campo("VL_ABERTURA", CampoTipo.Req)]
        public double Vl_Abertura { get; set; }
        [Campo("IN_FECHADO", CampoTipo.Req)]
        public string In_Fechado { get; set; }
        [Campo("DT_FECHADO", CampoTipo.Nul)]
        public DateTime Dt_Fechado { get; set; }
    }
}