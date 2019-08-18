using MORM.Infra.CrossCutting;
using System.Linq;

namespace MORM.Dominio.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsChavePreenchida(this object obj)
        {
            var camposKey = obj.GetType().GetCampos().Where(x => x.IsKey);
            var preenchido = camposKey.Any();

            foreach (var campo in camposKey)
            {
                var valueObj = campo.OwnerProp.GetValue(obj);
                if (valueObj?.IsValueNull() ?? true)
                {
                    preenchido = false;
                }
            }

            return preenchido;
        }
    }
}