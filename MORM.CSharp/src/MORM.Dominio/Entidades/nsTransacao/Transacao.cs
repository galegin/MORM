using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Entidades
{
    [Tabela("TRANSACAO")]
    public class Transacao : ITransacao
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public int Id_Transacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_EMPRESA", CampoTipo.Req)]
        public int Id_Empresa { get; set; }
        [Campo("ID_PESSOA", CampoTipo.Req)]
        public int Id_Pessoa { get; set; }
        [Campo("ID_OPERACAO", CampoTipo.Req)]
        public int Id_Operacao { get; set; }
        [Campo("TP_SITUACAO", CampoTipo.Req)]
        public int Tp_Situacao { get; set; }
        [Campo("TP_OPERACAO", CampoTipo.Req)]
        public int Tp_Operacao { get; set; }
        [Campo("TP_MODALIDADE", CampoTipo.Req)]
        public int Tp_Modalidade { get; set; }
        [Campo("DT_TRANSACAO", CampoTipo.Req)]
        public DateTime Dt_Transacao { get; set; }
        [Campo("NR_DOCUMENTONOTA", CampoTipo.Nul)]
        public string Nr_DocumentoNota { get; set; }

        [Relacao(nameof(Id_Empresa))]
        public IEmpresa Empresa { get; set; }
        [Relacao(nameof(Id_Pessoa))]
        public IPessoa Pessoa { get; set; }
        [Relacao(nameof(Id_Operacao))]
        public IOperacao Operacao { get; set; }

        [Relacao(nameof(Id_Transacao), RelacaoTipo.Update)]
        public ITransacaoFiscal Fiscal { get; set; }
        [Relacao(nameof(Id_Transacao), RelacaoTipo.Update)]
        public ICollection<ITransacaoItem> Itens { get; set; }
        [Relacao(nameof(Id_Transacao), RelacaoTipo.Update)]
        public ICollection<ITransacaoPagto> Pagtos { get; set; }

        public Transacao()
        {
            Empresa = new Empresa();
            Pessoa = new Pessoa();
            Operacao = new Operacao();
            Fiscal = new TransacaoFiscal();
            Itens = new List<ITransacaoItem>();
            Pagtos = new List<ITransacaoPagto>();
        }
    }
}
