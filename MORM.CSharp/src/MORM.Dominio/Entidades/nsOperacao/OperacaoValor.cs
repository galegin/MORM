using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("OPERACAO_VALOR")]
    public class OperacaoValor : IOperacaoValor
    {
        [Campo("ID_OPERACAOVALOR", CampoTipo.Key)]
        public int Id_OperacaoValor { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_OPERACAO", CampoTipo.Req)]
        public int Id_Operacao { get; set; }
        [Campo("ID_TIPOVALOR", CampoTipo.Req)]
        public int Id_TipoValor { get; set; }
        [Campo("IN_VALORPADRAO", CampoTipo.Req)]
        public bool In_ValorPadrao { get; set; }
    }
}