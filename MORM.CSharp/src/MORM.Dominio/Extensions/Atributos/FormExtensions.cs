using MORM.Dominio.Atributos;
using MORM.Dominio.Tipagens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Dominio.Extensions
{
    public static class FormExtensions
    {
        private static bool IsStartsWith(this string texto, CampoPreFixo[] lista)
        {
            foreach (var item in lista)
                if (texto.StartsWith(item.GetXmlEnum()))
                    return true;

            return false;
        }

        // controle

        private static string[] _listaDeControle =
            { "U_Version" };

        private static bool IsControle(CampoAttribute campo)
        {
            return _listaDeControle.Contains(campo.Atributo);
        }

        public static List<CampoAttribute> GetCamposControle(this Type type)
        {
            return type.GetCampos().Where(x => IsControle(x)).ToList();
        }

        // controle

        private static string[] _listaDeAtualizacao =
            { "Cd_Operador", "Dt_Cadastro" };

        private static bool IsAtualizacao(CampoAttribute campo)
        {
            return _listaDeAtualizacao.Contains(campo.Atributo);
        }

        public static List<CampoAttribute> GetCamposAtualizacao(this Type type)
        {
            return type.GetCampos().Where(x => IsAtualizacao(x)).ToList();
        }

        // chave

        public static List<CampoAttribute> GetCamposChave(this Type type)
        {
            return type.GetCampos().Where(x => x.IsKey).ToList();
        }

        // requerido

        public static List<CampoAttribute> GetCamposRequerido(this Type type)
        {
            return type.GetCampos().Where(x => x.IsReq).ToList();
        }

        // password

        public static List<CampoAttribute> GetCamposPassword(this Type type)
        {
            return type.GetCampos().Where(x => x.IsPwd).ToList();
        }

        // codigo

        private static CampoPreFixo[] _listaDeCodigo = 
            { CampoPreFixo.Codigo, CampoPreFixo.Numero };

        private static bool IsCodigo(CampoAttribute campo)
        {
            return campo.Atributo.IsStartsWith(_listaDeCodigo);
        }

        public static List<CampoAttribute> GetCamposCodigo(this Type type)
        {
            return type.GetCampos().Where(x => IsCodigo(x) && x.Atributo.Contains(type.Name)).ToList();
        }

        // descricao

        private static CampoPreFixo[] _listaDeDescricao = 
            { CampoPreFixo.Descricao, CampoPreFixo.Nome };

        private static bool IsDescricao(CampoAttribute campo)
        {
            return campo.Atributo.IsStartsWith(_listaDeDescricao);
        }

        public static List<CampoAttribute> GetCamposDescricao(this Type type)
        {
            return type.GetCampos().Where(x => IsDescricao(x) && x.Atributo.Contains(type.Name)).ToList();
        }

        // data

        private static CampoPreFixo[] _listaDeData = 
            { CampoPreFixo.Data, CampoPreFixo.DataHora, CampoPreFixo.Hora };

        private static bool IsData(CampoAttribute campo)
        {
            return campo.Atributo.IsStartsWith(_listaDeData);
        }

        public static List<CampoAttribute> GetCamposData(this Type type)
        {
            return type.GetCampos().Where(x => IsData(x)).ToList();
        }

        // valor

        private static CampoPreFixo[] _listaDeValor = 
            { CampoPreFixo.Percentual, CampoPreFixo.Quantidade, CampoPreFixo.Valor };

        private static bool IsValor(CampoAttribute campo)
        {
            return campo.Atributo.IsStartsWith(_listaDeValor);
        }

        public static List<CampoAttribute> GetCamposValor(this Type type)
        {
            return type.GetCampos().Where(x => IsValor(x)).ToList();
        }

        // filtro

        private static bool IsFiltro(CampoAttribute campo)
        {
            return (IsCodigo(campo) || IsData(campo) || IsDescricao(campo) || IsValor(campo)) 
                && !IsControle(campo) && !IsAtualizacao(campo);
        }

        public static List<CampoAttribute> GetCamposFiltro(this Type type)
        {
            return type.GetCampos().Where(x => IsFiltro(x)).ToList();
        }

        // pesquisa

        private static bool IsPesquisa(CampoAttribute campo)
        {
            return (IsCodigo(campo) || IsDescricao(campo))
                && !IsControle(campo) && !IsAtualizacao(campo);
        }
        
        public static List<CampoAttribute> GetCamposPesquisa(this Type type)
        {
            return type.GetCampos().Where(x => IsPesquisa(x)).ToList();
        }

        // listagem

        private static bool IsListagem(CampoAttribute campo)
        {
            return (IsCodigo(campo) || IsData(campo) || IsDescricao(campo) || IsValor(campo))
                && !IsControle(campo) && !IsAtualizacao(campo);
        }

        public static List<CampoAttribute> GetCamposListagem(this Type type)
        {
            return type.GetCampos().Where(x => IsListagem(x)).ToList();
        }
    }
}