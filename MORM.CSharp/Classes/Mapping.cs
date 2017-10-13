namespace MORM.Reppositorio.Classes
{
    public class TabelaAttribute
    {
        public TabelaAttribute : Attribute
        {
            public TabelaAttribute(string nome)
            {
                Nome = nome;
            }
            
            public string Nome { get; private set; }
        }
    }
    
    public enum CampoTipo
    {
        Key,
        Req,
        Nul
    }
    
    public class CampoAttribute
    {
        public CampoAttribute : Attribute
        {
            public CampoAttribute(string nome, CampoTipo tipo)
            {
                Nome = nome;
                Tipo = tipo;
            }
            
            public string Nome { get; private set; }
            public CampoTipo Tipo { get; private set; }
        }
    }
    
    public class RelacaoAttribute
    {
        public RelacaoAttribute : Attribute
        {
            public RelacaoAttribute(string campos)
            {
                Campos = campos;
            }
            
            public string Campos { get; private set; }
        }
    }
}