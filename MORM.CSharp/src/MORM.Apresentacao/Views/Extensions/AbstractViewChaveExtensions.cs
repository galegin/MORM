using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System.Linq;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewChaveExtensions
    {
        public static bool IsModelChavePreenchida(this object obj)
        {
            if (obj == null)
                return false;

            var camposKey = obj.GetType().GetMetadata().Campos.Where(x => x.IsKey());
            var preenchido = camposKey.Any();

            foreach (var campo in camposKey)
            {
                var valueObj = campo.Prop.GetValue(obj);
                if (valueObj?.IsValueNull() != false)
                {
                    preenchido = false;
                }
            }

            return preenchido;
        }

        public static bool IsModelChavePreenchida(this IAbstractViewModel vm)
        {
            return IsModelChavePreenchida(vm.Model);
        }
    }
}