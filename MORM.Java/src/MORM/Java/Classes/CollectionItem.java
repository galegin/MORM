package MORM.Java.Classes;

import java.lang.reflect.Field;

import MORM.Java.Classes.Mapping.CampoAttribute;
import MORM.Java.Classes.Mapping.Campos;
import MORM.Java.Classes.Mapping.Relacao;
import MORM.Java.Classes.Mapping.Tabela;
import MORM.Java.Classes.Mapping.TabelaAttribute;

public class CollectionItem
{
    public Tabela GetTabela()
    {
    	TabelaAttribute tabelaAttribute = (TabelaAttribute)this.getClass().getAnnotation(TabelaAttribute.class);
    	if (tabelaAttribute != null)
    		return new Mapping().new Tabela(tabelaAttribute.Nome());
    	else
    		return null;
    }
    
    public Campos GetCampos()
    {
    	Campos campos = new Mapping().new Campos();
    	for (Field field : getClass().getDeclaredFields())
    	{
    		CampoAttribute campoAttribute = (CampoAttribute)field.getAnnotation(CampoAttribute.class);
    		if (campoAttribute != null)
    			campos.add(new Mapping().new Campo(campoAttribute.Campo(), campoAttribute.Tipo(), field.getName()));
    	}
    	return campos;
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