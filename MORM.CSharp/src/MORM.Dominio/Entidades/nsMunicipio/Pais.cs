using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PAIS")]
    public class Pais : IPais
    {
        [Campo("ID_PAIS", CampoTipo.Key)]
        public int Id_Pais { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("NM_PAIS", CampoTipo.Req)]
        public string Nm_Pais { get; set; }
        [Campo("DS_SIGLA", CampoTipo.Req)]
        public string Ds_Sigla { get; set; }
    }
}