using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public static class ConsumerExtensions
    {
        public static string GetApi(this object instance,
            string urlPadrao = null,
            string svcPadrao = null,
            string mtdPadrao = null)
        {
            var retorno = new List<string>();

            var url = instance.GetUrl(urlPadrao);
            if (!string.IsNullOrWhiteSpace(url))
                retorno.Add(url);

            var svc = instance.GetSvc(svcPadrao);
            if (!string.IsNullOrWhiteSpace(svc))
                retorno.Add(svc);

            var mtd = instance.GetMtd(mtdPadrao);
            if (!string.IsNullOrWhiteSpace(mtd))
                retorno.Add(mtd);

            return string.Join("/", retorno);
        }

        public static string GetMtd(this object instance, string mtdPadrao = null)
        {
            return instance.GetTypeObjeto().GetAttribute<MTDAttribute>()?.Path ?? mtdPadrao;
        }

        public static string GetSvc(this object instance, string svcPadrao = null)
        {
            return instance.GetTypeObjeto().GetAttribute<SVCAttribute>()?.Path ?? svcPadrao;
        }

        public static string GetUrl(this object instance, string urlPadrao = null)
        {
            return instance.GetTypeObjeto().GetAttribute<URLAttribute>()?.Path ?? urlPadrao;
        }
    }
}