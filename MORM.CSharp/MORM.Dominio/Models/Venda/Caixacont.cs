using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("CAIXACONT")]
    public class Caixacont : CollectionItem
    {
        [Campo("ID_CAIXA", CampoTipo.Key)]
        public int Id_Caixa { get; set; }
        [Campo("ID_HISTREL", CampoTipo.Key)]
        public int Id_Histrel { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("VL_CONTADO", CampoTipo.Req)]
        public double Vl_Contado { get; set; }
        [Campo("VL_SISTEMA", CampoTipo.Req)]
        public double Vl_Sistema { get; set; }
        [Campo("VL_RETIRADA", CampoTipo.Req)]
        public double Vl_Retirada { get; set; }
        [Campo("VL_SUPRIMENTO", CampoTipo.Req)]
        public double Vl_Suprimento { get; set; }
        [Campo("VL_DIFERENCA", CampoTipo.Req)]
        public double Vl_Diferenca { get; set; }
    }
}