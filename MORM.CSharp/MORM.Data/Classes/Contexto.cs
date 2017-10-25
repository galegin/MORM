using System;
using System.Data.Common;
using System.Linq;
using MORM.Util.Classes;

namespace MORM.Data.Classes
{
    public class Contexto
    {
        public Contexto(Parametro parametro)
        {
            Parametro = parametro;
            Conexao = new Conexao(parametro);
            Comando = new Comando(parametro.TipoDatabase);
        }
        
        public Contexto() : this(new Parametro())
        {
        }
        
        public Parametro Parametro { get; private set; }
        public Conexao Conexao { get; private set; }
        public Comando Comando { get; private set; }
        
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
                    prop.SetValue(collectionItem, value, null);
                }
            }            
        }
        
        //-- relacao
        
        private void SetRelacaoLista(object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                var val = prop.GetValue(obj, new object[] {});
                if (val is Collection || val is CollectionItem)
                    SetRelacao(val);
            }
        }

        private void SetRelacao(object obj)
        {
            Relacao relacao = null;
            if (obj is Collection)
                relacao = (obj as Collection).GetRelacao();
            else if (obj is CollectionItem)
                relacao = (obj as CollectionItem).GetRelacao();
            else 
                return;
            
            var campos = RelacaoCampos.GetRelacaoCampos(relacao.Campos);
            
            var where = string.Empty;
            foreach (var campo in campos)
                AddString(ref where, campo.Atributo + " = " + Comando.GetValueStr(relacao.Owner, campo.AtributoRel), " and ", "");

            if (obj is Collection)
                GetLista(obj as Collection, where);
            else if (obj is CollectionItem)
                GetObjeto(obj as CollectionItem, where);                
        }

        //-- lista

        public Collection GetLista(Type collectionClass, string where)
        {
            var collection = new Collection(collectionClass);
            GetLista(collection, where);
            return collection;
        }
        
        public void GetLista(Collection collection, string where)
        {
            var sql = Comando.GetSelect(collection.CollectionItemClass, where);
            var dataReader = Conexao.GetConsulta(sql);
            while (dataReader.Read())
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

        public CollectionItem GetObjeto(Type collectionItemClass, string where = null)
        {
            var collectionItem = Activator.CreateInstance(collectionItemClass) as CollectionItem;
            GetObjeto(collectionItem, where ?? Comando.GetWhereKey(collectionItem));
            return collectionItem;
        }
        
        public void GetObjeto(CollectionItem collectionItem, string where = null)
        {
            var sql = Comando.GetSelect(collectionItem.GetType(), where ?? Comando.GetWhereKey(collectionItem));
            var dataReader = Conexao.GetConsulta(sql);
            if (dataReader.Read())
            {
                SetValue(dataReader, collectionItem);
                SetRelacaoLista(collectionItem);
            }
            dataReader.Close();
        }
        
        public void SetObjeto(CollectionItem collectionItem)
        {
            var sql = Comando.GetSelect(collectionItem);
            var dataReader = Conexao.GetConsulta(sql);
            var cmd = string.Empty;
            if (dataReader.Read())
                cmd = Comando.GetUpdate(collectionItem);
            else
                cmd = Comando.GetInsert(collectionItem);
            Conexao.ExecComando(cmd);
            dataReader.Close();
        }
        
        public void RemObjeto(CollectionItem collectionItem)
        {
            var cmd = Comando.GetDelete(collectionItem);
            Conexao.ExecComando(cmd);
        }
    }
}