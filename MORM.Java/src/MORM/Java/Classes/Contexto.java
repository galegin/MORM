package MORM.Java.Classes;

import java.lang.reflect.Field;
import java.sql.Date;
import java.sql.ResultSet;
import java.sql.SQLException;

public class Contexto
{
    public Contexto(Parametro parametro)
    {
        Parametro = parametro;
        Conexao = new Conexao(parametro);
        Comando = new Comando(parametro.TipoDatabase);
    }
    
    public Parametro Parametro;
    public Conexao Conexao;
    public Comando Comando;
    
    //-- value
    
    public void SetValue(ResultSet resultSet, CollectionItem collectionItem)
    {
		try {
	        Field[] fields = collectionItem.getClass().getDeclaredFields();
	        for (Field field : fields)
	        {
	        	field.setAccessible(true);
	        	String name = field.getName();
	        	Class<?> type = field.getType();
	        	
	            if (!resultSet.wasNull())
	            	field.set(collectionItem, null);
	            else if (type.isAssignableFrom(Boolean.class))
	            	field.set(collectionItem, ".1.S.SIM.T.TRUE.".indexOf(resultSet.getString(name)) > -1);
	            else if (type.isAssignableFrom(Date.class)) 
	                field.set(collectionItem, new Date(resultSet.getTimestamp(name).getTime()));
	            else if (type.isAssignableFrom(Float.class))
	                field.set(collectionItem, resultSet.getDouble(name));
	            else if (type.isAssignableFrom(Integer.class))
	                field.set(collectionItem, resultSet.getInt(name));
	            else if (type.isAssignableFrom(String.class))
	                field.set(collectionItem, resultSet.getString(name));
	            else
	                field.set(collectionItem, resultSet.getString(name));
	        }
		} catch (SQLException e) {
			e.printStackTrace();	        
		} catch (IllegalArgumentException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		}
    }
    
    //-- lista
    
    public Collection GetLista(Class<CollectionItem> collectionItemClass, String where)
    {
        Collection collection = new Collection(collectionItemClass);
        GetLista(collection, where);
        return collection;
    }
    
    public void GetLista(Collection collection, String where)
    {
        String sql = Comando.GetSelect(collection.CollectionItemClass, where);
        ResultSet resultSet = Conexao.GetConsulta(sql);
        try {
			while (resultSet.next())
			{
			    CollectionItem collectionItem = collection.AddItem();
			    SetValue(resultSet, collectionItem);
			}
		} catch (SQLException e) {
			e.printStackTrace();
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
    
    public CollectionItem GetObjeto(Class<CollectionItem> collectionItemClass, String where)
    {
        CollectionItem collectionItem = null;
		try {
			collectionItem = collectionItemClass.newInstance();
	        GetObjeto(collectionItem, where);
		} catch (InstantiationException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		}
        return collectionItem;
    }
    
    public void GetObjeto(CollectionItem collectionItem, String where)
    {
        try {
        	String sql = Comando.GetSelect(collectionItem.getClass(), where);
        	ResultSet resultSet = Conexao.GetConsulta(sql);
			if (resultSet.next())
			    SetValue(resultSet, collectionItem);
		} catch (SQLException e) {
			e.printStackTrace();
		}
    }
    
    public void SetObjeto(CollectionItem collectionItem)
    {
        try {
            String sql = Comando.GetSelect(collectionItem.getClass(), "");
            ResultSet resultSet = Conexao.GetConsulta(sql);
            String cmd = null;
			if (resultSet.next())
			    cmd = Comando.GetUpdate(collectionItem);
			else
			    cmd = Comando.GetInsert(collectionItem);
	        Conexao.ExecComando(cmd);
		} catch (SQLException e) {
			e.printStackTrace();
		}
    }
    
    public void RemObjeto(CollectionItem collectionItem)
    {
        String cmd = Comando.GetDelete(collectionItem);
        Conexao.ExecComando(cmd);
    }
}