using MORM.CrossCutting;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Mocks
{
    public static class BaseInstaller
    {
        public static void AddRepositorioMocks(this IAbstractContainer container)
        {
            container.Register<IEmpresaRepository, EmpresaRepositoryMock>();
            container.Register<IGrupoEmpresaRepository, GrupoEmpresaRepositoryMock>();
            container.Register<ITerminalRepository, TerminalRepositoryMock>();
            container.Register<IUsuarioRepository, UsuarioRepositoryMock>();
        }
    }
}