namespace MORM.Repositorio.Tests
{
    public class TesteService : ITesteService
    {
        private readonly ITesteRepository _testeRepository;

        public TesteService(ITesteRepository testeRepository)
        {
            _testeRepository = testeRepository;
        }
    }
}