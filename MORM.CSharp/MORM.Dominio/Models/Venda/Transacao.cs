using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSACAO")]
    public class Transacao : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_EMPRESA", CampoTipo.Req)]
        public int Id_Empresa { get; set; }
        [Campo("ID_PESSOA", CampoTipo.Req)]
        public string Id_Pessoa { get; set; }
        [Campo("ID_OPERACAO", CampoTipo.Req)]
        public string Id_Operacao { get; set; }
        [Campo("DT_TRANSACAO", CampoTipo.Req)]
        public DateTime Dt_Transacao { get; set; }
        [Campo("NR_TRANSACAO", CampoTipo.Req)]
        public int Nr_Transacao { get; set; }
        [Campo("TP_SITUACAO", CampoTipo.Req)]
        public int Tp_Situacao { get; set; }
        [Campo("DT_CANCELAMENTO", CampoTipo.Nul)]
        public DateTime Dt_Cancelamento { get; set; }
    }
}