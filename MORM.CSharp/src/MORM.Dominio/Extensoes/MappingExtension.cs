using MORM.Dominio.Atributos;
using System;
using System.Linq;
using System.Reflection;

namespace MORM.Dominio.Extensoes
{
    public static class MappingExtension
    {
        //-- tabela

        public static TabelaAttribute GetTabela(this Type type)
        {
            return type.GetAttribute<TabelaAttribute>();
        }

        public static TabelaAttribute GetTabela(this object obj)
        {
            return obj.GetType().GetTabela();
        }

        //-- campos

        private static CampoAttribute GetClone(this CampoAttribute campo, Type type, PropertyInfo prop)
        {
            return new CampoAttribute(campo.Nome, campo.Tipo, campo.Tamanho, campo.Precisao, type, prop);
        }

        public static Campos GetCampos(this Type type)
        {
            var campos = new Campos();
            foreach (var prop in type.GetProperties())
            {
                var campo = prop.GetAttribute<CampoAttribute>();
                if (campo != null)
                {
                    campos.Add(campo.GetClone(type, prop));
                }
            }
            return campos;
        }

        public static Campos GetCampos(this object obj)
        {
            return obj.GetType().GetCampos();
        }

        //-- relacao

        private static RelacaoAttribute GetClone(this RelacaoAttribute relacao, 
            Type ownerType = null, PropertyInfo ownerProp = null, object ownerObj = null)
        {
            return new RelacaoAttribute(relacao.Campos, relacao.Tipo, ownerType, ownerProp, ownerObj);
        }

        public static Relacoes GetRelacoes(this Type type, RelacaoTipo[] tipo, object ownerObj = null)
        {
            var relacoes = new Relacoes();
            foreach (var prop in type.GetProperties())
            {
                var relacao = prop.GetAttribute<RelacaoAttribute>();
                if (relacao != null && tipo.Contains(relacao.Tipo))
                {
                    relacoes.Add(relacao.GetClone(type, prop, ownerObj));
                }
            }
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

        //-- select max

        public static SelectMaxAttribute GetSelectMax(this PropertyInfo prop)
        {
            return prop.GetAttribute<SelectMaxAttribute>();
        }

        public static PropertyInfo GetCampoSelectMax(this Type type)
        {
            foreach (var prop in type.GetProperties())
            {
                var selectMax = prop.GetSelectMax();
                if (selectMax != null)
                {
                    return prop;
                }
            }

            return null;
        }
    }
}