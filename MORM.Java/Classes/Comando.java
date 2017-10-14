package MORM.Java.Classes;

public class Comando
{
    public String GetSelect(Class collectionItemClass, String where = "")
    {
        Tabela tabela = collectionItem.GetTabela();
        TList<Campo> campos = collectionItem.GetCampos();
        StringBuilder fieldsAtr = new StringBuilder();
        StringBuilder fields = new StringBuilder();

        for (Campo campo : campos)
        {
            AddString(fieldsAtr, campo.Atributo + " as \"" + campo.Atributo + "\"", ", ", "");
            AddString(fields, campo.Campo + " as " + campo.Atributo, ", ", "");
        }

        return
            "select " + fieldsAtr +
            " from (" +
              "select " + fields +
              " from " + vTabela.Nome + 
            ")" + (where != "" ? " where " + where : "")+
    }
    
    public String GetSelect(CollectionItem collectionItem, String where = "")
    {
        Tabela tabela = collectionItem.GetTabela();
        TList<Campo> campos = collectionItem.GetCampos();
        StringBuilder where = new StringBuilder();

        for (Campo campo : campos)
            if (campo.Tipo == CampoTipo.tfKey)
                AddString(where, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), " and ", "");

        return GetSelect(collectionItem.Class, where);
    }
    
    public String GetInsert(CollectionItem collectionItem)
    {
        Tabela tabela = collectionItem.GetTabela();
        TList<Campo> campos = collectionItem.GetCampos();
        StringBuilder fields = new StringBuilder();
        StringBuilder values = new StringBuilder();
        
        for (Campo campo : campos)
        {
            AddString(fields, campo.Atributo, ", ", "");
            AddString(values, GetValueStr(collectionItem, campo.Atributo), ", ", "");        
        }

        return
            "insert into " + vTabela.Nome + 
            "(" + fields + 
            ") values (" + values + ")" ;
    }
    
    public String GetUpdate(CollectionItem collectionItem)
    {
        Tabela tabela = collectionItem.GetTabela();
        TList<Campo> campos = collectionItem.GetCampos();
        StringBuilder sets = new StringBuilder();
        StringBuilder where = new StringBuilder();

        for (Campo campo : campos)
            if (campo.Tipo == CampoTipo.tfKey)
                AddString(sets, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), " and ", "");
            else
                AddString(sets, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), ", ", "");

        return
            "update " + vTabela.Nome + 
            " set " + sets + 
            " where " + where ;
    }
    
    public String GetDelete(CollectionItem collectionItem)
    {
        Tabela tabela = collectionItem.GetTabela();
        TList<Campo> campos = collectionItem.GetCampos();
        StringBuilder where = new StringBuilder();
        
        for (Campo campo : campos)
            if (campo.Tipo == CampoTipo.tfKey)
                AddString(where, campo.Atributo + " = " + GetValueStr(collectionItem, campo.Atributo), " and ", "");
        
        return
            "delete from " + vTabela.Nome + 
            " where " + where;
    }
}