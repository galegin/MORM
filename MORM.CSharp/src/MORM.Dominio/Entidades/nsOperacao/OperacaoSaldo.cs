using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("OPERACAO_SALDO")]
    public class OperacaoSaldo : IOperacaoSaldo
    {
        [Campo("ID_", CampoTipo.Key)]
        public int Id_OperacaoSaldo { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_OPERACAO", CampoTipo.Req)]
        public int Id_Operacao { get; set; }
        [Campo("ID_TIPOSALDO", CampoTipo.Req)]
        public int Id_TipoSaldo { get; set; }
        [Campo("IN_GERARSALDO", CampoTipo.Req)]
        public bool In_GerarSaldo { get; set; }
    }
}