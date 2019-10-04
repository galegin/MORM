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

    public class SVCAttribute : Attribute
    {
        public SVCAttribute(string path)
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