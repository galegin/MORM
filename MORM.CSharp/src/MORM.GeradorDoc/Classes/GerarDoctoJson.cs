using System;
using Newtonsoft.Json;

namespace MORM.GeradorDoc
{
    /// <summary>
    /// criado por MFGALEGO em 16/08/2018 11:41:37
    /// classe GerarDoctoJson.cs
    /// funcao  geracao dicionario formato json
    /// </summary>
    internal class GerarDoctoJson : GerarDocto
    {
        public GerarDoctoJson()
        {
            Formato = ".json";
        }

        protected override string GerarCampo(Type type)
        {
            var objeto = Activator.CreateInstance(type);
            var objetoStr = JsonConvert.SerializeObject(objeto, Formatting.Indented);
            return objetoStr;
        }
    }
}