using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Entidades
{
    [Tabela("OPERACAO")]
    public class Operacao : IOperacao
    {
        [Campo("ID_OPERACAO", CampoTipo.Key)]
        public int Id_Operacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_REGRAFISCAL", CampoTipo.Req)]
        public int Id_RegraFiscal { get; set; }
        [Campo("CD_OPERACAO", CampoTipo.Req)]
        public string Cd_Operacao { get; set; }
        [Campo("DS_OPERACAO", CampoTipo.Req)]
        public string Ds_Operacao { get; set; }
        [Campo("TP_OPERACAO", CampoTipo.Req)]
        public int Tp_Operacao { get; set; }
        [Campo("TP_MODALIDADE", CampoTipo.Req)]
        public int Tp_Modalidade { get; set; }
        [Campo("IN_GERARFINANCEIRO", CampoTipo.Req)]
        public bool In_GerarFinanceiro { get; set; }
        [Campo("IN_GERARFISCAL", CampoTipo.Req)]
        public bool In_GerarFiscal { get; set; }
        [Campo("IN_GERARSALDO", CampoTipo.Req)]
        public bool In_GerarSaldo { get; set; }

        [Relacao(nameof(Id_RegraFiscal))]
        public IRegraFiscal RegraFiscal { get; set; }

        [Relacao(nameof(Id_Operacao), RelacaoTipo.Update)]
        public ICollection<IOperacaoSaldo> Saldos { get; set; }
        [Relacao(nameof(Id_Operacao), RelacaoTipo.Update)]
        public ICollection<IOperacaoValor> Valores { get; set; }

        public Operacao()
        {
            Saldos = new List<IOperacaoSaldo>();
            Valores = new List<IOperacaoValor>();
        }
    }
}