package MORM.Java.Classes;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;
import java.util.ArrayList;

public class Mapping
{
    //-- tabela
	
	public class Tabela
    {
        public Tabela(String nome)
        {
            Nome = nome;
        }
        
        public String Nome;
    }
	
	@Target(ElementType.TYPE)
	@Retention(RetentionPolicy.RUNTIME)
	public @interface TabelaAttribute
	{
		String Nome();
	}

	//-- campo
    
    public enum CampoTipo
    {
    	Key,
    	Req,
    	Nul
    }
    
    public class Campo
    {
        public Campo(String campo, CampoTipo tipo, String atributo)
        {
            Campo = campo;
            Tipo = tipo;
            Atributo = atributo;
        }
        
        public String Campo;
        public CampoTipo Tipo;
        public String Atributo;
    }
    
	@Target(ElementType.FIELD)
	@Retention(RetentionPolicy.RUNTIME)
	public @interface CampoAttribute
	{
		String Campo();
		CampoTipo Tipo() default CampoTipo.Nul;
		String Atributo() default "";
	}    
    
    @SuppressWarnings("serial")
	public class Campos extends ArrayList<Campo>
    {
    }
    
    //-- relacao
    
    public class Relacao
    {
        public Relacao(Object owner, String campos)
        {
            Owner = owner;
            Campos = campos;
        }
        
        public Object Owner;
        public String Campos;
    }
    
    public class RelacaoCampo
    {
    	public RelacaoCampo(String atributo, String atributoRel)
    	{
    		Atributo = atributo;
    		AtributoRel = atributoRel;
    	}
    	
    	public String Atributo;
    	public String AtributoRel;    	
    }
    
    @SuppressWarnings("serial")
	public class RelacaoCampos extends ArrayList<RelacaoCampo>
    {
    	public RelacaoCampos(String campos)
    	{
    		String[] lista = campos.split(";");
    		for (String item : lista)
    		{
    			if (item.indexOf("=") > -1)
    			{
        			String[] value = item.split("=");
    				this.add(new RelacaoCampo(value[0], value[1]));
    			}
    			else
    			{
    				this.add(new RelacaoCampo(item, item));    			
    			}
    		}
    	}
    }
}