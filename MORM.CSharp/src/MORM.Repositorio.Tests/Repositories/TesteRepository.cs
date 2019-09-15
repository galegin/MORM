using System;
using MORM.Repositorio.Mocks;

namespace MORM.Repositorio.Tests
{
    public class TesteRepository : RepositoryMock<TesteModel>, ITesteRepository
    {
        public TesteRepository()
        {
            for (int codigo = 1; codigo <= 10; codigo++)
                Add(GetTeste(codigo));
        }

        private TesteModel GetTeste(int codigo)
        {
            return new TesteModel
            {
                Cd_Teste = codigo,
                Ds_Teste = $"Teste {codigo}",
                Dt_Teste = DateTime.Now,
                Nr_Teste = 2,
                In_Ativo = true,
                Vl_Teste = 3,
                Cd_Tipo = 1
            };
        }
    }
}