using MORM.Infra.CrossCutting;
using System;

namespace MORM.Aplicacao.Doc
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