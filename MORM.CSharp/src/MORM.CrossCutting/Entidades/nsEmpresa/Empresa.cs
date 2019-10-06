using System;

namespace MORM.CrossCutting
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

        [Relacao(new[] { nameof(Id_GrupoEmpresa) })]
        public GrupoEmpresa GrupoEmpresa { get; set; }

        public override bool Equals(object obj)
        {
            var empresa = obj as Empresa;
            return empresa != null && Id_Empresa == empresa.Id_Empresa;
        }

        public override int GetHashCode()
        {
            return -384371728 + Id_Empresa.GetHashCode();
        }
    }
}