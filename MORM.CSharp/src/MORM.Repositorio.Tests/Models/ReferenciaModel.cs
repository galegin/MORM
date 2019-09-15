using MORM.Dominio.Atributos;

namespace MORM.Repositorio.Tests
{
    [Tabela("REFERENCIA")]
    public class ReferenciaModel
    {
        public ReferenciaModel()
        {
            Tipo = new TipoModel();
            Teste = new TesteModel();
        }

        [Campo("CD_REFERENCIA", CampoTipo.Key)]
        public int Cd_Referencia { get; set; }
        [Campo("DS_REFERENCIA", CampoTipo.Req)]
        public string Ds_Referencia { get; set; }
        [Campo("TP_REFERENCIA", CampoTipo.Req)]
        public TipoEnum TipoEnum { get; set; } = TipoEnum.Normal;

        public TipoModel Tipo { get; set; } = new TipoModel();
        public TesteModel Teste { get; set; } = new TesteModel();

        public override bool Equals(object obj)
        {
            return (obj as ReferenciaModel)?.Cd_Referencia == Cd_Referencia;
        }

        public override int GetHashCode()
        {
            return 1857009019 + Cd_Referencia.GetHashCode();
        }
    }
}