using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public enum SituacaoTransacao
    {
        EmAndamento = 1,
        Recebida,
        Cancelada
    }

    public interface ITransacao
    {
        int Id_Transacao { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Empresa { get; set; }
        int Id_Pessoa { get; set; }
        int Id_Operacao { get; set; }
        int Tp_Situacao { get; set; }
        int Tp_Operacao { get; set; }
        int Tp_Modalidade { get; set; }
        DateTime Dt_Transacao { get; set; }
        string Nr_DocumentoNota { get; set; }

        IEmpresa Empresa { get; set; }
        IPessoa Pessoa { get; set; }
        IOperacao Operacao { get; set; }
        ITransacaoFiscal Fiscal { get; set; }
        ICollection<ITransacaoItem> Itens { get; set; }
        ICollection<ITransacaoPagto> Pagtos { get; set; }
    }
}
