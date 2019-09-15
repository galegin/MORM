namespace MORM.Repositorio.Tests
{
    public class ReferenciaService : IReferenciaService
    {
        private readonly IReferenciaRepository _ReferenciaRepository;

        public ReferenciaService(IReferenciaRepository ReferenciaRepository)
        {
            _ReferenciaRepository = ReferenciaRepository;
        }
    }
}