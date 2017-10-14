package MORM.Java.Classes;

public class CollectionItem
{
    public Tabela GetTabela()
    {
    }
    
    public TList<Campo> GetCampos()
    {
    }
    
    private Relacao relacao;
    
    public Relacao SetRelacao(Object owner, String campos)
    {
        relacao = new Relacao(owner, campos);
    }

    public Relacao GetRelacao()
    {
        return relacao;
    }
}