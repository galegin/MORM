using System;
using System.Reflection;

namespace MORM.Utilidade.Atributos
{
    public enum PesquisaTipo
    {
        Descricao,
        Listagem,
        Ambas,
    }

    //-- galeg - 16/07/2018 18:23:20
    public class PesquisaAttribute : Attribute
    {
        public PesquisaAttribute(Type classe, PesquisaTipo tipo, string campoDescricao = null, object ownerProp = null)
        {
            Classe = classe ?? throw new ArgumentNullException(nameof(classe));
            Tipo = tipo;
            if (IsDescricao)
                CampoDescricao = campoDescricao ?? throw new ArgumentNullException(nameof(campoDescricao));
            OwnerProp = ownerProp as PropertyInfo;
        }

        public Type Classe { get; }
        public PesquisaTipo Tipo { get; }
        public string CampoDescricao { get; }
        public PropertyInfo OwnerProp { get; }

        public bool IsDescricao => (Tipo != PesquisaTipo.Listagem);
        public bool IsListagem => (Tipo != PesquisaTipo.Descricao);
    }
}