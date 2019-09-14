using MORM.CrossCutting;

namespace MORM.Aplicacao.WebApi
{
    public static class BaseInstaller
    {
        public static void AddAplicacaoWebApi(this IAbstractContainer container)
        {
            container
                .RegisterAll(
                    ClassesAssembly
                        .GetTypes(null, (t) => t.Name.EndsWith("Controller"))
                        .ToArray());
        }
    }
}