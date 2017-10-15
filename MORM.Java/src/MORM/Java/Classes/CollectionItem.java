package MORM.Java.Classes;

import MORM.Java.Classes.Mapping.Campos;
import MORM.Java.Classes.Mapping.Relacao;
import MORM.Java.Classes.Mapping.Tabela;

public class CollectionItem
{
    public Tabela GetTabela()
    {
    	return null;
    }
    
    public Campos GetCampos()
    {
    	return null;
    }
    
    protected Relacao relacao;
    
    public void SetRelacao(Object owner, String campos)
    {
        //relacao = new Relacao(owner, campos);
    }

    public Relacao GetRelacao()
    {
        return relacao;
    }
}