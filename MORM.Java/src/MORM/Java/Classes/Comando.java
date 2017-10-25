package MORM.Java.Classes;

import MORM.Java.Classes.Mapping.Campo;
import MORM.Java.Classes.Mapping.CampoTipo;
import MORM.Java.Classes.Mapping.Campos;
import MORM.Java.Classes.Mapping.Tabela;

public class Comando
{
	public Comando(TipoDatabase tipoDatabase)
	{
		TipoDatabase = tipoDatabase;
	}
	
	public TipoDatabase TipoDatabase;
	
    protected Tabela GetTabela(Class<? extends CollectionItem> collectionItemClass)
    {
    	Tabela tabela = null;
		try {
	  		CollectionItem collecitonItem = collectionItemClass.newInstance();
	  		tabela = collecitonItem.GetTabela();
		} catch (InstantiationException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		}
  		return tabela;
    }
    
    protected Campos GetCampos(Class<? extends CollectionItem> collectionItemClass)
    {
    	Campos campos = null;
		try {
	  		CollectionItem collecitonItem = collectionItemClass.newInstance();
	  		campos = collecitonItem.GetCampos();
		} catch (InstantiationException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		}
  		return campos;
    }
    
    protected void AddString(StringBuilder str, String sub, String sep, String ini)
    {
    	str.append((str.length() > -1 ? sep : ini) + sub);
    }
    
    private String GetValueStr(CollectionItem collectionItem, String atributo) 
    {
		return null;
	}
	
	public String GetSelect(Class<? extends CollectionItem> collectionItemClass, String where)
    {
        Tabela tabela = GetTabela(collectionItemClass);
        Campos campos = GetCampos(collectionItemClass);
        StringBuilder fieldsAtr = new StringBuilder();
        StringBuilder fields = new StringBuilder();

        for (Campo campo : campos)
        {
            AddString(fieldsAtr, campo.Atributo + " as \"" + campo.Atributo + "\"", ", ", "");
            AddString(fields, campo.Campo + " as " + campo.Atributo, ", ", "");
        }

        return
            "select " + fieldsAtr.toString() +
            " from (" +
              "select " + fields.toString() +
              " from " + tabela.Nome + 
            ")" + (where != "" ? " where " + where : "");
    }
    
    public String GetSelect(CollectionItem collectionItem)
    {
        Campos campos = collectionItem.GetCampos();
        StringBuilder where = new StringBuilder();

        for (Campo campo : campos)
            if (campo.Tipo == CampoTipo.Key)
                AddString(where, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), " and ", "");

        return GetSelect(collectionItem.getClass(), where.toString());
    }

	public String GetInsert(CollectionItem collectionItem)
    {
        Tabela tabela = collectionItem.GetTabela();
        Campos campos = collectionItem.GetCampos();
        StringBuilder fields = new StringBuilder();
        StringBuilder values = new StringBuilder();
        
        for (Campo campo : campos)
        {
            AddString(fields, campo.Atributo, ", ", "");
            AddString(values, GetValueStr(collectionItem, campo.Atributo), ", ", "");        
        }

        return
            "insert into " + tabela.Nome + 
            "(" + fields.toString() + 
            ") values (" + values + ")" ;
    }
    
    public String GetUpdate(CollectionItem collectionItem)
    {
        Tabela tabela = collectionItem.GetTabela();
        Campos campos = collectionItem.GetCampos();
        StringBuilder sets = new StringBuilder();
        StringBuilder where = new StringBuilder();

        for (Campo campo : campos)
            if (campo.Tipo == CampoTipo.Key)
                AddString(sets, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), " and ", "");
            else
                AddString(sets, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), ", ", "");

        return
            "update " + tabela.Nome + 
            " set " + sets.toString() + 
            " where " + where.toString();
    }
    
    public String GetDelete(CollectionItem collectionItem)
    {
        Tabela tabela = collectionItem.GetTabela();
        Campos campos = collectionItem.GetCampos();
        StringBuilder where = new StringBuilder();
        
        for (Campo campo : campos)
            if (campo.Tipo == CampoTipo.Key)
                AddString(where, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), " and ", "");
        
        return
            "delete from " + tabela.Nome + 
            " where " + where.toString();
    }
}