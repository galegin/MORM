using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;
using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Extensions
{
    public static class ParametroExtensions
    {
        public static IList<IParametro> GetParametros(this object obj, CampoTipo[] campoTipos = null)
        {
            var parametros = new List<IParametro>();

            var campos = obj.GetType().GetCampos();

            foreach (var campo in campos)
            {
                if (campoTipos == null || campoTipos.Contains(campo.Tipo))
                {
                    var valor = obj.GetInstancePropOrField(campo.Atributo);
                    parametros.Add(new Parametro(campo.Atributo, valor));
                }
            }

            return parametros;
        }

        public static IList<IParametro> GetParametrosKey(this object obj)
        {
            return obj.GetParametros(new[] { CampoTipo.Key });
        }

        public static IList<IParametro> GetParametrosReq(this object obj)
        {
            return obj.GetParametros(new[] { CampoTipo.Req });
        }

        public static IList<IParametro> GetParametrosNul(this object obj)
        {
            return obj.GetParametros(new[] { CampoTipo.Nul });
        }
    }
}