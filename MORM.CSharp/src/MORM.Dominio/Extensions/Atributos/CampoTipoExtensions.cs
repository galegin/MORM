using MORM.Dominio.Atributos;
using MORM.Infra.CrossCutting;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
    public static class CampoTipoExtensions
    {
        public static CampoTipo? GetCampoTipoProp(this PropertyInfo prop)
        {
            if (prop.GetAttribute<KeyAttribute>() != null)
                return CampoTipo.Key;
            else if (prop.GetAttribute<RequiredAttribute>() != null)
                return CampoTipo.Req;

            var campoTipo = prop.GetAttribute<CampoAttribute>();
            return campoTipo?.Tipo;
        }
    }
}