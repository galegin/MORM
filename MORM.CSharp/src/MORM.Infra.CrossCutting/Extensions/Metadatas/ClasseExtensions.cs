using System;
using System.Linq;

namespace MORM.Infra.CrossCutting
{
    public static class ClasseExtensions
    {
        public static string GetCampoCod(this Type type)
        {
            return type
                .GetMetadata()
                .Campos
                .Where(c => c.IsChave)
                .FirstOrDefault()
                .Prop.Name
                ;
        }

        public static string GetCampoDes(this Type type)
        {
            return type
                .GetMetadata()
                .Campos
                .Where(c => c.IsDescr)
                .FirstOrDefault()
                .Prop.Name
                ;
        }
    }
}