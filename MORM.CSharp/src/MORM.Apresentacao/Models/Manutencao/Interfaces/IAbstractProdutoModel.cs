namespace MORM.Apresentacao.Models.Manutencao
{
    public interface IAbstractProdutoModel : IAbstractModel
    {
        int Codigo { get; }
        string Descricao { get; }
    }
}