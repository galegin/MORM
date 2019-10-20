using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public enum CampoTipo
    {
        Key,
        Req,
        Nul,
        Pwd
    }

    public static class CampoTipoExtensions
    {
        public static CampoTipo? GetCampoTipoProp(this PropertyInfo prop)
        {
            if (prop.GetAttribute<KeyAttribute>() != null)
                return CampoTipo.Key;
            else if (prop.GetAttribute<RequiredAttribute>() != null)
                return CampoTipo.Req;

            var campoTipo = prop.GetAttribute<CampoAttribute>();
            return campoTipo?.Tipo;
        }

        public static CampoTipo GetCampoTipo(this PropertyInfo prop)
        {
            var campo = prop.GetAttribute<CampoAttribute>();
            return campo?.Tipo ?? CampoTipo.Nul;
        }

        public static bool IsKey(this CampoTipo tipo) => tipo.In(CampoTipo.Key);
        public static bool IsReq(this CampoTipo tipo) => tipo.In(CampoTipo.Req);
        public static bool IsNul(this CampoTipo tipo) => tipo.In(CampoTipo.Nul);
        public static bool IsPwd(this CampoTipo tipo) => tipo.In(CampoTipo.Pwd);
    }

    public class CampoAttribute : Attribute
    {
        public CampoAttribute(string nome, CampoTipo tipo = CampoTipo.Nul,
            int tamanho = 0, int precisao = 0, Type ownerType = null, object ownerProp = null)
        {
            Nome = nome;
            Tipo = tipo;
            Tamanho = tamanho;
            Precisao = precisao;
            OwnerProp = ownerProp as PropertyInfo;
            OwnerType = ownerType;
        }

        public string Nome { get; private set; }
        public CampoTipo Tipo { get; private set; }
        public int Tamanho { get; private set; }
        public int Precisao { get; private set; }
        public Type OwnerType { get; private set; }
        public PropertyInfo OwnerProp { get; private set; }

        public string Atributo => OwnerProp.Name ?? Nome;
        public Type DataType => OwnerProp.PropertyType;

        public bool IsKey => (Tipo == CampoTipo.Key);
        public bool IsReq => (Tipo == CampoTipo.Key || Tipo == CampoTipo.Req);
        public bool IsPwd => (Tipo == CampoTipo.Pwd);
    }

    public static class CampoExtensions
    {
        private static CampoAttribute GetClone(this CampoAttribute campo, Type type, PropertyInfo prop)
        {
            return new CampoAttribute(campo.Nome, campo.Tipo, campo.Tamanho, campo.Precisao, type, prop);
        }

        public static Campos GetCampos(this Type type)
        {
            var campos = new Campos();

            type?
                .GetProperties()
                .ToList()
                .ForEach(prop =>
                {
                    var campo = prop.GetAttribute<CampoAttribute>()?.GetClone(type, prop);
                    if (campo != null)
                        campos.Add(campo);
                });

            return campos;
        }

        public static Campos GetCampos(this object obj)
        {
            return obj.GetType().GetCampos();
        }
    }

    public class Campos : List<CampoAttribute> { }
}