using System;
using System.Collections.Generic;

namespace MORM.Util.Atributos
{
	//-- tabela
	
    public class Tabela : Attribute
    {
        public Tabela(string nome)
        {
            Nome = nome;
        }
        
        public string Nome { get; private set; }
    }
    
    //-- campo

    public enum CampoTipo
    {
        Key,
        Req,
        Nul
    }
   
    public class Campo : Attribute
    {
        public Campo(string nome, CampoTipo tipo = CampoTipo.Nul, string atributo = "")
        {
            Nome = nome;
            Tipo = tipo;
            Atributo = atributo;
        }
        
        public string Nome { get; private set; }
        public CampoTipo Tipo { get; private set; }
        public string Atributo { get; private set; }
    }
    
    public class Campos : List<Campo> {}
    
    //-- relacao
    
    public class Relacao
    {
        public Relacao(object owner, string campos)
        {
        	Owner = owner;
            Campos = campos;
        }
        
        public object Owner { get; private set; }
        public string Campos { get; private set; }
    }
    
    public class RelacaoCampo
    {
    	public RelacaoCampo(string atributo, string atributoRel = "")
    	{
    		Atributo = atributo;
    		AtributoRel = (atributoRel != "" ? atributoRel : atributo);
    	}
    	
  		public string Atributo { get; private set; }
  		public string AtributoRel { get; private set; }
    }
    
    public static class RelacaoCampos
    {
    	public static List<RelacaoCampo> GetRelacaoCampos(string campos)
    	{
    		var relacaoCampos = new List<RelacaoCampo>();
    		
    		var campoList = campos.Split(';');
    		foreach(var campoStr in campoList)
    		{
    			if (campoStr.IndexOf('=') > -1)
    			{
    				var campoValue = campoStr.Split('=');
    				relacaoCampos.Add(new RelacaoCampo(campoValue[0], campoValue[1]));
    			}
    			else
    				relacaoCampos.Add(new RelacaoCampo(campoStr));
    		}    		
    		
    		return relacaoCampos;
    	}
    }
}