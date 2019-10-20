using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public enum RelacaoTipo
    {
        Update,
        NoUpdate,
    }

    public class RelacaoAttribute : Attribute
    {
        public RelacaoAttribute(string[] campos, 
            RelacaoTipo tipo = RelacaoTipo.NoUpdate,
            Type ownerType = null, object ownerProp = null, object ownerObj = null)
        {
            Campos = campos;
            Tipo = tipo;
            OwnerType = ownerType;
            OwnerProp = ownerProp as PropertyInfo;
            OwnerObj = ownerObj;
        }

        public RelacaoAttribute(string campo,
            RelacaoTipo tipo = RelacaoTipo.NoUpdate)
        {
            Tipo = tipo;
            Campos = new[] { campo };
        }

        public string[] Campos { get; private set; }
        public RelacaoTipo Tipo { get; private set; }
        public Type OwnerType { get; set; }
        public PropertyInfo OwnerProp { get; set; }
        public object OwnerObj { get; set; }
    }

    public static class RelacaoExtensions
    {
        private static RelacaoAttribute GetClone(this RelacaoAttribute relacao,
            Type ownerType = null, PropertyInfo ownerProp = null, object ownerObj = null)
        {
            return new RelacaoAttribute(relacao.Campos, relacao.Tipo, ownerType, ownerProp, ownerObj);
        }

        public static Relacoes GetRelacoes(this Type type, RelacaoTipo[] tipo, object ownerObj = null)
        {
            var relacoes = new Relacoes();

            type?
                .GetProperties()
                .ToList()
                .ForEach(prop =>
                {
                    var relacao = prop.GetAttribute<RelacaoAttribute>()?.GetClone(type, prop, ownerObj);
                    if (relacao != null)
                        relacoes.Add(relacao);
                });

            return relacoes;
        }

        private static RelacaoTipo[] _listaDeRelacaoTipoGet =
            { RelacaoTipo.Update, RelacaoTipo.NoUpdate };

        public static Relacoes GetRelacoesGet(this Type type, object ownerObj = null)
        {
            return GetRelacoes(type, _listaDeRelacaoTipoGet, ownerObj);
        }

        private static RelacaoTipo[] _listaDeRelacaoTipoSet =
            { RelacaoTipo.Update };

        public static Relacoes GetRelacoesSet(this Type type, object ownerObj = null)
        {
            return GetRelacoes(type, _listaDeRelacaoTipoSet, ownerObj);
        }
    }

    public class Relacoes : List<RelacaoAttribute> { }

    public class RelacaoCampo
    {
        public RelacaoCampo(string atributo, string atributoRel = null)
        {
            Atributo = atributo;
            AtributoRel = !string.IsNullOrWhiteSpace(atributoRel) ? atributoRel : atributo;
        }
        
        public string Atributo { get; private set; }
        public string AtributoRel { get; private set; }
    }
    
    public static class RelacaoCampos
    {
        public static List<RelacaoCampo> GetRelacaoCampos(string[] campos)
        {
            var relacaoCampos = new List<RelacaoCampo>();
            
            foreach(var campo in campos)
            {
                if (campo.IndexOf('=') > -1)
                {
                    var campoValue = campo.Split('=');
                    relacaoCampos.Add(new RelacaoCampo(campoValue[0], campoValue[1]));
                }
                else
                    relacaoCampos.Add(new RelacaoCampo(campo));
            }            
            
            return relacaoCampos;
        }
    }
}