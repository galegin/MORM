using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Mocks;

namespace MORM.Repositorio.Mocks
{
    public class EmpresaRepositoryMock : RepositoryMock<Empresa>, IEmpresaRepository
    {
    }
}