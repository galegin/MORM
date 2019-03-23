using MORM.Dominio.Atributos;
using System.Linq;

namespace MORM.Dominio.Extensoes
{
    public static class ConsumerExtensions
    {
        public static string GetApi<TEntrada>()
        {
            return $"{(typeof(TEntrada).GetCustomAttributes(true).FirstOrDefault(x => x is APIAttribute) as APIAttribute)?.Path ?? typeof(TEntrada).Name}";
        }

        public static string GetUrl<TEntrada>()
        {
            return $"{(typeof(TEntrada).GetCustomAttributes(true).FirstOrDefault(x => x is URLAttribute) as URLAttribute)?.Path ?? typeof(TEntrada).Name}";
        }
    }
}