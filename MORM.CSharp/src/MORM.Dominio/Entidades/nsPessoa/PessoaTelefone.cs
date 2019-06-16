using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PESSOA_TELEFONE")]
    public class PessoaTelefone : IPessoaTelefone
    {
        [Campo("ID_PESSOATELEFONE", CampoTipo.Key)]
        public int Id_PessoaTelefone { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_PESSOA", CampoTipo.Req)]
        public int Id_Pessoa { get; set; }
        [Campo("TP_TELEFONE", CampoTipo.Req)]
        public int Tp_Telefone { get; set; }
        [Campo("DS_DDI", CampoTipo.Req)]
        public string Ds_DDI { get; set; }
        [Campo("DS_DDD", CampoTipo.Req)]
        public string Ds_DDD { get; set; }
        [Campo("DS_TELEFONE", CampoTipo.Req)]
        public string Ds_Telefone { get; set; }
        [Campo("IN_PADRAO", CampoTipo.Req)]
        public bool In_Padrao { get; set; }
    }
}