using MORM.Repositorio.Mocks;

namespace MORM.Repositorio.Tests
{
    public class TipoRepository : RepositoryMock<TipoModel>, ITipoRepository
    {
        public TipoRepository()
        {
            for (int codigo = 1; codigo <= 10; codigo++)
                Add(GetTipo(codigo));
        }

        private TipoModel GetTipo(int codigo)
        {
            return new TipoModel
            {
                Cd_Tipo = codigo,
                Ds_Tipo = $"Tipo {codigo}",
            };
        }
    }
}