using MORM.Apresentacao.Views;
using MORM.WSist.ViewsModel.Manutencao;

namespace MORM.WSist.Views.Manutencao
{
    public class AbstractProdutoViewManut : AbstractViewManut, IAbstractProdutoViewManut
    {
        public AbstractProdutoViewManut()
        {
            var vm = new AbstractProdutoViewModel();
            CreateCampos(vm, vm.Model);
            DataContext = vm;
        }
    }
}