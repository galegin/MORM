using System;
using MORM.Repositorio.Mocks;

namespace MORM.Repositorio.Tests
{
    public class ReferenciaRepository : RepositoryMock<ReferenciaModel>, IReferenciaRepository
    {
        public ReferenciaRepository()
        {
            for (int codigo = 1; codigo <= 10; codigo++)
                Add(GetReferencia(codigo));
        }

        private ReferenciaModel GetReferencia(int codigo)
        {
            return new ReferenciaModel()
            {
                Tipo = new TipoModel
                {
                    Cd_Tipo = codigo,
                    Ds_Tipo = $"Tipo {codigo}",
                },
                Teste = new TesteModel
                {
                    Cd_Teste = codigo,
                    Ds_Teste = $"Teste {codigo}",
                }
            };
        }
    }
}