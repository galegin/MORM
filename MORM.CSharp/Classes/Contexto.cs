namespace MORM.Reppositorio.Classes
{
    public class Contexto
    {
        public Contexto(Parametro parametro)
        {
            Parametro = parametro;
            Conexao = new Conexao(parametro)
        }
        
        public Parametro Parametro { get; private set; }
        public Conexao Conexao { get; private set; }
        
        //--
        
        private void SetValue(DataReader dataReader, CollectionItem collectionItem)
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                var prop = obj.GetType().GetProperties()
                    .FirstOrDefault(x => x.Name == reader.GetName(i));
                if (prop != null)
                {
                    var value = (
                        reader.IsDBNull(i) ? null :
                        prop.PropertyType == typeof(bool) ? ".1.S.SIM.T.TRUE.".Contains(Convert.ToString(dataReader.GetValue(i))) :
                        prop.PropertyType == typeof(DateTime) ? Convert.ToDateTime(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(decimal) ? Convert.ToDecimal(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(double) ? Convert.ToDouble(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(int) ? Convert.ToInt32(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(string) ? Convert.ToString(dataReader.GetValue(i)) : dataReader.GetValue(i));
                    prop.SetValue(obj, value, null);
                }
            }            
        }
        
        //--

        private void SetRelacaoLista(TObject obj)
        {
            Relacao relacao = null;
            if (obj is Collection)
                relacao = (obj as Collection).GetRelacao();
            else if (obj is CollectionItem)
                relacao = (obj as CollectionItem).GetRelacao();
            else 
                return;
            
            var campos = relacao.GetCampos();
            
            var where = string.Empty;
            foreach (var campo in campos)
                AddString(ref where, Atributo + ' = ' + GetValueStr(relacao.Owner, AtributoRel), ' and ', '');

            if (obj is Collection)
                GetLista(obj as Collection, where);
            else if (obj is CollectionItem)
                GetObjeto(obj as CollectionItem, where);                
        }

        //--

        public Collection GetLista(Type collectionClass, string where)
        {
            var collection = Activator.CreateInstance(collectionClass) as Collection;
            GetLista(collection, where);
            return collection;
        }
        
        public void GetLista(Collection collection, string where)
        {
            var sql = collection.GetSelect(where);
            var dataReader = Conexao.GetConsulta(sql);
            while (dataReader.Next())
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
        
        //--

        public CollectionItem GetObjeto(Type collectionItemClass, string where)
        {
            var collectionItem = Activator.CreateInstance(collectionItemClass) as CollectionItem;
            GetObjeto(collectionItem, where);
            return collectionItem;
        }
        
        public void GetObjeto(CollectionItem collectionItem, string where)
        {
            var sql = collectionItem.GetSelect(where);
            var dataReader = Conexao.GetConsulta(sql);
            if (dataReader.Next())
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
            if (dataReader.Next())
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