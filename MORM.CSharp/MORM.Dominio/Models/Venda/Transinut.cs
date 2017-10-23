using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSINUT")]
    public class Transinut : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("DT_EMISSAO", CampoTipo.Req)]
        public DateTime Dt_Emissao { get; set; }
        [Campo("TP_MODELONF", CampoTipo.Req)]
        public int Tp_Modelonf { get; set; }
        [Campo("CD_SERIE", CampoTipo.Req)]
        public string Cd_Serie { get; set; }
        [Campo("NR_NF", CampoTipo.Req)]
        public int Nr_Nf { get; set; }
        [Campo("DT_RECEBIMENTO", CampoTipo.Nul)]
        public DateTime Dt_Recebimento { get; set; }
        [Campo("NR_RECIBO", CampoTipo.Nul)]
        public string Nr_Recibo { get; set; }
    }
}