using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
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

    public static class TipagemExtension
    {
        //-- validacao

        public static TipagemCampo GetTipagemCampo(this PropertyInfo prop)
        {
            return prop.GetCustomAttributes(false)
                .ToList()
                .Where(attr => attr.GetType() == typeof(TipagemCampo))
                .ToList()
                .ConvertAll(attr => (TipagemCampo)attr)
                .FirstOrDefault()
                ;
        }

        public static void ValidarTipagens(this object obj)
        {
            if (obj == null)
                return;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var tipagemCampo = prop.GetTipagemCampo();
                if (tipagemCampo != null)
                {
                    try
                    {
                        var value = prop.GetValue(obj);
                        if (value != null)
                        {
                            var lista = TipagemCampoItems.GetTipagemCampoItems(tipagemCampo.Tipagens);
                            if (lista.Any(x => x.Codigo == value.ToString()) == false)
                                throw new Exception($"O valor {value} nao esta contido na lista {lista.ToString()}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Erro($"Entidade: {obj.GetType().Name} / Campo: {prop.Name}", ex: ex);
                        throw ex;
                    }
                }
            }
        }
    }
}