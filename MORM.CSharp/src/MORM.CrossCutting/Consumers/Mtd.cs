using System;

namespace MORM.CrossCutting
{
    public class MTDAttribute : Attribute
    {
        public MTDAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }

    public static class MTDExtensions
    {
        public static string GetMtd(this object instance, string mtdPadrao = null)
        {
            return instance.GetTypeObjeto().GetAttribute<MTDAttribute>()?.Path ?? mtdPadrao;
        }
    }
}