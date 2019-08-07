using MORM.Dominio.Atributos;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;
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
        public static bool IsKey(this MetadataCampoTipo tipo) => tipo == MetadataCampoTipo.Key;
        public static bool IsReq(this MetadataCampoTipo tipo) => tipo == MetadataCampoTipo.Req;
        public static bool IsNul(this MetadataCampoTipo tipo) => tipo == MetadataCampoTipo.Nul;
        public static bool IsPwd(this MetadataCampoTipo tipo) => tipo == MetadataCampoTipo.Pwd;
    }

    public class MetadataCampo
    {
        public PropertyInfo Prop { get; set; }
        public MetadataCampoTipo Tipo { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Precisao { get; set; }
        public string Formato { get; set; }
        public IList Valores { get; set; }
        public Type Classe { get; set; }
        public bool IsExibir { get; set; }
        public bool IsEditar { get; set; }
    }

    public static class MetadataCampoExtensions
    {
        public static bool IsKey(this MetadataCampo campo) => campo.Tipo.IsKey();
        public static bool IsReq(this MetadataCampo campo) => campo.Tipo.IsReq();
        public static bool IsNul(this MetadataCampo campo) => campo.Tipo.IsNul();
        public static bool IsPwd(this MetadataCampo campo) => campo.Tipo.IsPwd();
        public static bool IsValores(this MetadataCampo campo) => campo.Valores != null;
        public static bool IsClasse(this MetadataCampo campo) => campo.Classe != null;
    }

    public class Metadata
    {
        public Type ElementType { get; set; }
        public List<MetadataCampo> Campos { get; set; }

        internal object Any()
        {
            throw new NotImplementedException();
        }
    }

    public static class MetadataExtensions
    {
        private static Dictionary<Type, Metadata> _metadatas = new Dictionary<Type, Metadata>();

        public static Metadata GetMetadata(this Type type)
        {
            var metadata = _metadatas.ContainsKey(type) ? _metadatas[type] : null;
            if (metadata == null)
            {
                _metadatas[type] = metadata = type.GetMetadataType();
            }

            return metadata;
        }
        
        public static Metadata GetMetadataType(this Type type)
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
                        Formato = prop.GetFormato(),
                        Valores = prop.GetValoresCampo(),
                        Classe = prop.GetClasseCampo(),
                    };
                });

            return new Metadata
            {
                ElementType = type,
                Campos = campos,
            };
        }

        public static MetadataCampo GetCampo(this Metadata metadata, string nome)
        {
            return metadata.Campos.FirstOrDefault(x => x.Prop.Name == nome);
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