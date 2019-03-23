using System;
using System.Collections.Generic;

namespace MORM.Dominio.Atributos
{
    public class TipagemCampo : Attribute
    {
        public TipagemCampo(string[] tipagens)
        {
            Tipagens = tipagens;
        }

        public string[] Tipagens { get; private set; }
    }

    public class TipagemCampoItem
    {
        public TipagemCampoItem(string codigo, string descricao = "")
        {
            Codigo = codigo;
            Descricao = (descricao != "" ? descricao : codigo);
        }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
    }

    public static class TipagemCampoItems
    {
        public static List<TipagemCampoItem> GetTipagemCampoItems(string[] tipagens)
        {
            var tipagemItems = new List<TipagemCampoItem>();

            foreach (var tipagen in tipagens)
            {
                if (tipagen.IndexOf('=') > -1)
                {
                    var tipagemValue = tipagen.Split('=');
                    tipagemItems.Add(new TipagemCampoItem(tipagemValue[0], tipagemValue[1]));
                }
                else
                    tipagemItems.Add(new TipagemCampoItem(tipagen));
            }

            return tipagemItems;
        }
    }
}