namespace MORM.Repositorio.Tests
{
    public class TipoService : ITipoService
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }
    }
}