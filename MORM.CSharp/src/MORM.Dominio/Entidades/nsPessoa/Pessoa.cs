using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Entidades
{
    [Tabela("PESSOA")]
    public class Pessoa : IPessoa
    {
        [Campo("ID_PESSOA", CampoTipo.Key)]
        public int Id_Pessoa { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("NM_PESSOA", CampoTipo.Req)]
        public string Nm_Pessoa { get; set; }
        [Campo("TP_PESSOA", CampoTipo.Req)]
        public string Tp_Pessoa { get; set; }
        [Campo("TP_DOCUMENTO", CampoTipo.Req)]
        public int Tp_Documento { get; set; }
        [Campo("NR_DOCUMENTO", CampoTipo.Req)]
        public string Nr_Documento { get; set; }
        [Campo("TP_INSCRICAO", CampoTipo.Req)]
        public int Tp_Inscricao { get; set; }
        [Campo("NR_INSCRICAO", CampoTipo.Req)]
        public string Nr_Inscricao { get; set; }
        [Campo("TP_REGIMETRIBUTARIO", CampoTipo.Req)]
        public int Tp_RegimeTributario { get; set; }

        [Relacao(nameof(Id_Pessoa), RelacaoTipo.Update)]
        public ICollection<IPessoaEmail> Emails { get; set; }
        [Relacao(nameof(Id_Pessoa), RelacaoTipo.Update)]
        public ICollection<IPessoaEndereco> Enderecos { get; set; }
        [Relacao(nameof(Id_Pessoa), RelacaoTipo.Update)]
        public ICollection<IPessoaTelefone> Telefones { get; set; }

        public Pessoa()
        {
            Emails = new List<IPessoaEmail>();
            Enderecos = new List<IPessoaEndereco>();
            Telefones = new List<IPessoaTelefone>();
        }
    }
}