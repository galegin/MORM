using System;
using System.Data.Common;
using System.Linq;
using MORM.Util.Atributos;
using MORM.Util.Classes;

namespace MORM.Data.Classes
{
    public class Contexto
    {
        public Contexto(Parametro parametro)
        {
            Parametro = parametro;
            Conexao = new Conexao(parametro);
        }
        
        public Contexto() : this(new Parametro())
        {
        }
        
        public Parametro Parametro { get; private set; }
        public Conexao Conexao { get; private set; }
        
        //-- string
        
        private void AddString(ref string str, string sub, string sep, string ini = "")
        {
        	str += (str != "" ? sep : ini) + sub;
        }
        
        //-- value
        
        private void SetValue(DbDataReader dataReader, CollectionItem collectionItem)
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                var prop = collectionItem.GetType().GetProperties()
                    .FirstOrDefault(x => x.Name == dataReader.GetName(i));
                if (prop != null)
                {
                    var value = (
                        dataReader.IsDBNull(i) ? null :
                        prop.PropertyType == typeof(bool) ? ".1.S.SIM.T.TRUE.".Contains(Convert.ToString(dataReader.GetValue(i))) :
                        prop.PropertyType == typeof(DateTime) ? Convert.ToDateTime(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(decimal) ? Convert.ToDecimal(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(double) ? Convert.ToDouble(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(int) ? Convert.ToInt32(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(string) ? Convert.ToString(dataReader.GetValue(i)) : dataReader.GetValue(i));
                    prop.SetValue(dataReader, value, null);
                }
            }            
        }
        
        public string GetValueStr(object obj, string attr)
        {
        	return null;
        }        	
        
        //-- relacao

        private void SetRelacaoLista(object obj)
        {
            Relacao relacao = null;
            if (obj.GetType() == typeof(Collection))
                relacao = (obj as Collection).GetRelacao();
            else if (obj.GetType() == typeof(CollectionItem))
                relacao = (obj as CollectionItem).GetRelacao();
            else 
                return;
            
            var campos = RelacaoCampos.GetRelacaoCampos(relacao.Campos);
            
            var where = string.Empty;
            foreach (var campo in campos)
                AddString(ref where, campo.Atributo + " = " + GetValueStr(relacao.Owner, campo.AtributoRel), " and ", "");

            if (obj.GetType() == typeof(Collection))
                GetLista(obj as Collection, where);
            else if (obj.GetType() == typeof(CollectionItem))
                GetObjeto(obj as CollectionItem, where);                
        }

        //-- lista

        public Collection GetLista(Type collectionClass, string where)
        {
            var collection = Activator.CreateInstance(collectionClass) as Collection;
            GetLista(collection, where);
            return collection;
        }
        
        public void GetLista(Collection collection, string where)
        {
            var sql = collection.CollectionItemClass.GetSelect(where);
            var dataReader = Conexao.GetConsulta(sql);
            while (dataReader.NextResult())
            {
                var collectionItem = collection.AddItem();
                SetValue(dataReader, collectionItem);
                SetRelacaoLista(collectionItem);
            }
            dataReader.Close();
        }
        
        public void SetLista(Collection collection)
        {
            foreach (var collectionItem in collection)
                SetObjeto(collectionItem);
        }
        
        public void RemLista(Collection collection)
        {
            foreach (var collectionItem in collection)
                RemObjeto(collectionItem);
        }
        
        //-- objeto

        public CollectionItem GetObjeto(Type collectionItemClass, string where)
        {
            var collectionItem = Activator.CreateInstance(collectionItemClass) as CollectionItem;
            GetObjeto(collectionItem, where);
            return collectionItem;
        }
        
        public void GetObjeto(CollectionItem collectionItem, string where)
        {
        	var sql = collectionItem.GetType().GetSelect(where);
            var dataReader = Conexao.GetConsulta(sql);
            if (dataReader.NextResult())
            {
                SetValue(dataReader, collectionItem);
                SetRelacaoLista(collectionItem);
            }
            dataReader.Close();
        }
        
        public void SetObjeto(CollectionItem collectionItem)
        {
            var sql = collectionItem.GetSelect();
            var dataReader = Conexao.GetConsulta(sql);
            var cmd = string.Empty;
            if (dataReader.NextResult())
                cmd = collectionItem.GetUpdate();
            else
                cmd = collectionItem.GetInsert();
            Conexao.ExecComando(cmd);
            dataReader.Close();
        }
        
        public void RemObjeto(CollectionItem collectionItem)
        {
            var cmd = collectionItem.GetDelete();
            Conexao.ExecComando(cmd);
        }
    }
}