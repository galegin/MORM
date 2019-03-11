namespace MORM.Apresentacao.Models.Manutencao
{
    public class AbstractProdutoModel : AbstractModel, IAbstractProdutoModel
    {
        public override string GetFiltroKey() =>
            $"{nameof(Codigo)} = {Codigo}";

        private int _codigo;
        public int Codigo
        { 
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        
        private string _descricao;
        public string Descricao 
        { 
            get => _descricao;
            set => SetField(ref _descricao, value);
        }
    }
}