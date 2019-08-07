using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;
using System.Linq;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewChaveExtensions
    {
        public static bool IsModelChavePreenchida(this IAbstractViewModel vm)
        {
            var camposKey = vm.ElementType.GetMetadata().Campos.Where(x => x.IsKey());
            var preenchido = camposKey.Any();

            foreach (var campo in camposKey)
            {
                var valueObj = campo.Prop.GetValue(vm.Model);
                var valueNul = campo.Prop.PropertyType.GetValueNull();
                if (valueObj == null || valueNul.Equals(valueObj))
                {
                    preenchido = false;
                }
            }

            return preenchido;
        }
    }
}