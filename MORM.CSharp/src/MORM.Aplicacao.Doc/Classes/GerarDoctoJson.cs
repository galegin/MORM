using MORM.CrossCutting;
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
            var objetoStr = objeto.GetJson(isIndented: true);
            return objetoStr;
        }
    }
}