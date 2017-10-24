using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSDFE")]
    public class Transdfe : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("NR_SEQUENCIA", CampoTipo.Key)]
        public int Nr_Sequencia { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("TP_EVENTO", CampoTipo.Req)]
        public int Tp_Evento { get; set; }
        [Campo("TP_AMBIENTE", CampoTipo.Req)]
        public int Tp_Ambiente { get; set; }
        [Campo("TP_EMISSAO", CampoTipo.Req)]
        public int Tp_Emissao { get; set; }
        [Campo("DS_ENVIOXML", CampoTipo.Req)]
        public string Ds_Envioxml { get; set; }
        [Campo("DS_RETORNOXML", CampoTipo.Nul)]
        public string Ds_Retornoxml { get; set; }
    }
}