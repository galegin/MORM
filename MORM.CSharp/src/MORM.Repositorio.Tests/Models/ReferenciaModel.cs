namespace MORM.Repositorio.Tests
{
    //-- galeg - 13/10/2018 11:59:20
    public class ReferenciaModel
    {
        public TipoEnum TipoEnum { get; set; } = TipoEnum.Normal;
        public TipoModel Tipo { get; set; } = new TipoModel();
        public TesteModel Teste { get; set; } = new TesteModel();
    }
}