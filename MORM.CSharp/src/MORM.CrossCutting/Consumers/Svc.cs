using System;

namespace MORM.CrossCutting
{
    public class SVCAttribute : Attribute
    {
        public SVCAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }

    public static class SVCExtensions
    {
        public static string GetSvc(this object instance, string svcPadrao = null)
        {
            return instance.GetTypeObjeto().GetAttribute<SVCAttribute>()?.Path ?? svcPadrao;
        }
    }
}