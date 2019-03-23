namespace MORM.Repositorio.Tests
{
    public class ReferenciaModel
    {
        public TipoEnum TipoEnum { get; set; } = TipoEnum.Normal;
        public TipoModel Tipo { get; set; } = new TipoModel();
        public TesteModel Teste { get; set; } = new TesteModel();
    }
}