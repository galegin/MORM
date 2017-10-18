using MORM.CSharp.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("HISTREL")]
    public class Histrel : CollectionItem
    {
        [Campo("ID_HISTREL", CampoTipo.Key)]
        public int Id_Histrel { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("TP_DOCUMENTO", CampoTipo.Req)]
        public int Tp_Documento { get; set; }
        [Campo("CD_HISTREL", CampoTipo.Req)]
        public int Cd_Histrel { get; set; }
        [Campo("DS_HISTREL", CampoTipo.Req)]
        public string Ds_Histrel { get; set; }
        [Campo("NR_PARCELAS", CampoTipo.Req)]
        public int Nr_Parcelas { get; set; }
    }
}