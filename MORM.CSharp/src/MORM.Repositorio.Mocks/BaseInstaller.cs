using MORM.CrossCutting;

namespace MORM.Repositorio.Mocks
{
    public static class BaseInstaller
    {
        public static void AddRepositorioMocks(this IAbstractContainer container)
        {
            //container.Register<IClasseRepository, ClasseRepositoryMock>();
        }
    }
}