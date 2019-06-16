using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("EMPRESA")]
    public class Empresa : IEmpresa
    {
        [Campo("ID_EMPRESA", CampoTipo.Key)]
        public int Id_Empresa { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_GRUPOEMPRESA", CampoTipo.Nul)]
        public int Id_GrupoEmpresa { get; set; }
        [Campo("CD_EMPRESA", CampoTipo.Req)]
        public string Cd_Empresa { get; set; }
        [Campo("DS_EMPRESA", CampoTipo.Req)]
        public string Ds_Empresa { get; set; }

        [Relacao(nameof(Id_GrupoEmpresa))]
        public IGrupoEmpresa GrupoEmpresa { get; set; }

        public Empresa()
        {
            GrupoEmpresa = new GrupoEmpresa();
        }
    }
}