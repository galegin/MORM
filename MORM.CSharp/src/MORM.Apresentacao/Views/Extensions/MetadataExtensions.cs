using MORM.Apresentacao.Extensions;
using MORM.Dominio.Atributos;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.Apresentacao.Views
{
    public enum MetadataCampoTipo
    {
        Key,
        Req,
        Nul,
        Pwd
    }

    public static class MetadataCampoTipoExtensions
    {
        public static bool IsKey(this MetadataCampoTipo tipo) => 
            tipo == MetadataCampoTipo.Key;
        public static bool IsReq(this MetadataCampoTipo tipo) => 
            tipo == MetadataCampoTipo.Req;
        public static bool IsNul(this MetadataCampoTipo tipo) => 
            tipo == MetadataCampoTipo.Nul;
        public static bool IsPwd(this MetadataCampoTipo tipo) => 
            tipo == MetadataCampoTipo.Pwd;
    }

    public class MetadataCampo
    {
        public PropertyInfo Prop { get; set; }
        public MetadataCampoTipo Tipo { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Precisao { get; set; }
    }

    public class Metadata
    {
        public Type ElementType { get; set; }
        public List<MetadataCampo> Campos { get; set; }

        public MetadataCampo GetCampo(string nome)
        {
            return Campos.FirstOrDefault(x => x.Prop.Name == nome);
        }
    }

    public static class MetadataExtensions
    {
        public static Metadata GetMetadata(this Type type)
        {
            var campoTipo = MetadataCampoTipo.Key;

            var campos = type
                .GetProperties()
                .ToList()
                .ConvertAll(prop =>
                {
                    if (prop.Name.ToLower() == "id")
                        campoTipo = MetadataCampoTipo.Key;
                    else if (prop.Name.ToLower() == "u_version")
                        campoTipo = MetadataCampoTipo.Req;

                    // Key / Req / Nul / Pwd
                    var campoTipoAttr = prop.GetCampoTipoProp();
                    if (campoTipoAttr != null)
                        campoTipo = campoTipoAttr.Value.GetMetadataCampoTipo();

                    return new MetadataCampo
                    {
                        Prop = prop,
                        Tipo = campoTipo,
                        Descricao = prop.GetDescricao().GetTraducao(),
                        Tamanho = prop.GetTamanho(),
                        Precisao = prop.GetPrecisao(),
                    };
                });

            return new Metadata
            {
                ElementType = type,
                Campos = campos,
            };
        }

        private static MetadataCampoTipo GetMetadataCampoTipo(this CampoTipo tipo)
        {
            Enum.TryParse(tipo.ToString(), out MetadataCampoTipo retorno);
            return retorno;
        }

        public static MetadataCampo GetMetadataProp(this PropertyInfo prop)
        {
            var metadata = prop.ReflectedType.GetMetadata();
            return metadata.GetCampo(prop.Name);
        }
    }
}