using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PESSOA_EMAIL")]
    public class PessoaEmail : IPessoaEmail
    {
        [Campo("ID_PESSOAEMAIL", CampoTipo.Key)]
        public int Id_PessoaEmail { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_PESSOA", CampoTipo.Req)]
        public int Id_Pessoa { get; set; }
        [Campo("TP_EMAIL", CampoTipo.Req)]
        public int Tp_Email { get; set; }
        [Campo("DS_EMAIL", CampoTipo.Req)]
        public string Ds_Email { get; set; }
        [Campo("IN_PADRAO", CampoTipo.Req)]
        public bool In_Padrao { get; set; }
    }
}