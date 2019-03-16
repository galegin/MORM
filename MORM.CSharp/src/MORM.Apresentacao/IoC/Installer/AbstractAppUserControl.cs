using MORM.Apresentacao.Commands.Manutencao;
using MORM.Apresentacao.Models.Manutencao;
using MORM.Apresentacao.ViewModels.Manutencao;
using MORM.Apresentacao.Views.Manutencao;
using MORM.Ioc.Installer;

namespace MORM.Apresentacao.Ioc.Installer
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