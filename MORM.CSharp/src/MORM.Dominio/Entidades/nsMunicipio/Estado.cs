using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("ESTADO")]
    public class Estado : IEstado
    {
        [Campo("ID_ESTADO", CampoTipo.Key)]
        public int Id_Estado { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_PAIS", CampoTipo.Req)]
        public int Id_Pais { get; set; }
        [Campo("CD_ESTADO", CampoTipo.Req)]
        public string Cd_Estado { get; set; }
        [Campo("NM_ESTADO", CampoTipo.Req)]
        public string Nm_Estado { get; set; }
        [Campo("DS_SIGLA", CampoTipo.Req)]
        public string Ds_Sigla { get; set; }

        [Relacao(nameof(Id_Pais))]
        public IPais Pais { get; set; }

        public Estado()
        {
            Pais = new Pais();
        }
    }
}