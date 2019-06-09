using MORM.Utils.Extensions;
using System;

namespace MORM.GeradorDoc
{
    internal class GerarDoctoJson : GerarDocto
    {
        public GerarDoctoJson()
        {
            Formato = ".json";
        }

        protected override string GerarCampo(Type type)
        {
            var objeto = Activator.CreateInstance(type);
            var objetoStr = objeto.GetJsonFromObject(isIndented: true);
            return objetoStr;
        }
    }
}