using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;

namespace MORM.WSist.Models.Manutencao
{
    [SVC("Produto")]
    public class AbstractProdutoModel : AbstractModel
    {
        #region variaveis
        private int _codigo;
        private string _descricao;
        #endregion

        #region propriedades
        public int Codigo
        { 
            get => _codigo;
            set => SetField(ref _codigo, value);
        }       
        public string Descricao 
        { 
            get => _descricao;
            set => SetField(ref _descricao, value);
        }
        #endregion
    }
}