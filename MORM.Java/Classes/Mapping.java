package MORM.Java.Classes;

public class Mapping
{
    public class Tabela
    {
        public Tabela(String nome)
        {
            Nome = nome;
        }
        
        public String Nome;
    }
    
    public class Campo
    {
        public Tabela(String campo)
        {
            Campo = campo;
        }
        
        public String Campo;
    }
    
    public class Relacao
    {
        public Tabela(Object owner, String campos)
        {
            Owner = owner;
            Campos = campos;
        }
        
        public Object Owner;
        public String Campos ;
    }
}