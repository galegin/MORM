using System;
using System.Collections.Generic;
using System.Reflection;

namespace MORM.Utilidade.Atributos
{
    //-- tabela
    
    public class TabelaAttribute : Attribute
    {
        public TabelaAttribute(string nome)
        {
            Nome = nome;
        }
        
        public string Nome { get; private set; }
    }

    //-- campo

    public enum CampoTipo
    {
        Key,
        Req,
        Nul
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
    }
    
    public class Campos : List<CampoAttribute> {}

    //-- relacao

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

        public string[] Campos { get; private set; }
        public RelacaoTipo Tipo { get; private set; }
        public Type OwnerType { get; set; }
        public PropertyInfo OwnerProp { get; set; }
        public object OwnerObj { get; set; }
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

    //-- select max

    public class SelectMaxAttribute : Attribute
    {
    }
}