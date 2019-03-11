using MORM.Apresentacao.Commands.Manutencao;
using MORM.Apresentacao.Models.Manutencao;
using MORM.Apresentacao.ViewModels.Manutencao;
using MORM.Apresentacao.Views.Manutencao;
using MORM.IoC.Installer;

namespace MORM.Apresentacao.IoC.Installer
{
    public class AbstractAppUserControl : AbstractInstaller
    {
        protected override void Setup()
        {
            Register<IAbstractClienteManutCommand, AbstractClienteManutCommand>();
            Register<IAbstractClienteModel, AbstractClienteModel>();
            Register<IAbstractClienteViewModel, AbstractClienteViewModel>();
            Register<IAbstractClienteViewManut, AbstractClienteViewManut>();

            Register<IAbstractProdutoManutCommand, AbstractProdutoManutCommand>();
            Register<IAbstractProdutoModel, AbstractProdutoModel>();
            Register<IAbstractProdutoViewModel, AbstractProdutoViewModel>();
            Register<IAbstractProdutoViewManut, AbstractProdutoViewManut>();
        }
    }
}