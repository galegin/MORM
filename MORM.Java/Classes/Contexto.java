package MORM.Java.Classes;

public class Contexto
{
    public Conexao(Parametro parametro)
    {
        Parametro = parametro;
        Conexao = new Conexao(parametro);
    }
    
    public Parametro Parametro;
    public Conexao Conexao;
    
    //-- lista
    
    public Collection GetLista(Class collectionClass, String where)
    {
        Collection collection = new TClass(collectionClass);
        GetLista(collection, where);
        return collection;
    }
    
    public void GetLista(Collection collection, String where)
    {
        String sql = Comando.GetSelect(collection.CollectionItemClass, where);
        DataReader = Conexao.GetConsulta(sql);
        while (DataReader.Next())
        {
            CollectionItem collectionItem = collection.AddItem();
            SetValue(DataReader, collectionItem);
        }
    }
    
    public void SetLista(Collection collection)
    {
        for (CollectionItem collectionItem : collection)
            SetObjeto(collectionItem);
    }
    
    public void RemLista(Collection collection)
    {
        for (CollectionItem collectionItem : collection)
            RemObjeto(collectionItem);
    }
    
    //-- objeto
    
    public CollectionItem GetObjeto(Class collectionItemClass, String where)
    {
        CollectionItem collectionItem = new TClass(collectionItemClass);
        GetObjeto(collectionItem, where);
        return collectionItem;
    }
    
    public void GetObjeto(CollectionItem collectionItem, String where)
    {
        String sql = Comando.GetSelect(collectionItem, where);
        DataReader = Conexao.GetConsulta(sql);
        if (DataReader.Next())
            SetValue(DataReader, collectionItem);
    }
    
    public void SetObjeto(CollectionItem collectionItem)
    {
        String sql = Comando.GetSelect(collectionItem);
        DataReader = Conexao.GetConsulta(sql);
        String cmd = null;
        if (DataReader.Next())
            cmd = Comando.GetUpdate(collectionItem);
        else
            cmd = Comando.GetInsert(collectionItem);
        Conexao.ExecComando(cmd);
    }
    
    public void RemObjeto(CollectionItem collectionItem)
    {
        String cmd = Comando.GetDelete(collectionItem);
        Conexao.ExecComando(cmd);
    }
}