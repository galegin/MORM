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
    
    private Relacao relacao;
    
    public void SetRelacao(Object owner, String campos)
    {
    	this.relacao = new Mapping().new Relacao(owner, campos);
    }

    public Relacao GetRelacao()
    {
        return this.relacao;
    }
}