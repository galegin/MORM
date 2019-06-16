using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TRANSACAO_PAGTO")]
    public class TransacaoPagto : ITransacaoPagto
    {
        [Campo("ID_TRANSACAOPAGTO", CampoTipo.Key)]
        public int Id_TransacaoPagto { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_TRANSACAO", CampoTipo.Req)]
        public int Id_Transacao { get; set; }
        [Campo("TP_DOCUMENTO", CampoTipo.Req)]
        public int Tp_Documento { get; set; }
        [Campo("NR_DOCUMENTO", CampoTipo.Req)]
        public int Nr_Documento { get; set; }
        [Campo("DT_VENCIMENTO", CampoTipo.Req)]
        public DateTime Dt_Vencimento { get; set; }
        [Campo("VL_DOCUMENTO", CampoTipo.Req)]
        public double Vl_Documento { get; set; }
        [Campo("QT_PARCELA", CampoTipo.Req)]
        public int Qt_Parcela { get; set; }
        [Campo("NR_PARCELA", CampoTipo.Req)]
        public int Nr_Parcela { get; set; }
        [Campo("CD_AUTORIZACAO", CampoTipo.Req)]
        public string Cd_Autorizacao { get; set; }
        [Campo("NR_NSU", CampoTipo.Req)]
        public string Nr_Nsu { get; set; }
        [Campo("DS_OPERADORA", CampoTipo.Req)]
        public string Ds_Operadora { get; set; }
        [Campo("DS_BANDEIRA", CampoTipo.Req)]
        public string Ds_Bandeira { get; set; }
        [Campo("NR_BANCO", CampoTipo.Req)]
        public int Nr_Banco { get; set; }
        [Campo("NR_AGENCIA", CampoTipo.Req)]
        public int Nr_Agencia { get; set; }
        [Campo("NR_CONTA", CampoTipo.Req)]
        public int Nr_Conta { get; set; }
        [Campo("NR_CHEQUE", CampoTipo.Req)]
        public int Nr_Cheque { get; set; }
        [Campo("DS_BANDA", CampoTipo.Req)]
        public string Ds_Banda { get; set; }
    }
}