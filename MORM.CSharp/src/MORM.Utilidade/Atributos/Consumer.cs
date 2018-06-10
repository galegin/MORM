using System;

namespace MORM.Utilidade.Atributos
{
    //-- galeg - 01/05/2018 15:56:34

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