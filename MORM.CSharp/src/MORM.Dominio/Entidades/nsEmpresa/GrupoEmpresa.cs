using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("GRUPO_EMPRESA")]
    public class GrupoEmpresa : IGrupoEmpresa
    {
        [Campo("ID_GRUPOEMPRESA", CampoTipo.Key)]
        public int Id_GrupoEmpresa { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_GRUPOEMPRESA", CampoTipo.Req)]
        public string Cd_GrupoEmpresa { get; set; }
        [Campo("DS_GRUPOEMPRESA", CampoTipo.Req)]
        public string Nm_GrupoEmpresa { get; set; }
    }
}