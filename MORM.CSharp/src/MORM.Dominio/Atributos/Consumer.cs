using System;

namespace MORM.Dominio.Atributos
{
    public class APIAttribute : Attribute
    {
        public APIAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }

    public class URLAttribute : Attribute
    {
        public URLAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}