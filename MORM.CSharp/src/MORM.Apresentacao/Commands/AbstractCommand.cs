using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Models;
using MORM.Apresentacao.ViewModels;
using System;

namespace MORM.Apresentacao.Commands
{
    public abstract class AbstractCommand : IAbstractCommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class AbstractConnectorCommand : AbstractCommand
    {
        protected AbstractConnector<IAbstractModel> _connector { get; } =
            new AbstractConnector<IAbstractModel>();
    }

    public class AbstractFecharCommand : AbstractCommand, IAbstractFecharCommand
    {
        public override void Execute(object parameter)
        {
        }
    }

    public class AbstractVoltarCommand : AbstractCommand, IAbstractVoltarCommand
    {
        public override void Execute(object parameter)
        {
        }
    }

    public class AbstractLimparCommand : AbstractCommand, IAbstractLimparCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            vm.ClearLista();

            vm.ClearModel();
        }
    }

    public class AbstractListarCommand : AbstractConnectorCommand, IAbstractListarCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            var listaRet = _connector.Listar((f) => f.GetFiltroAll());

            vm.SetLista(listaRet);
        }
    }

    public class AbstractConsultarCommand : AbstractConnectorCommand, IAbstractConsultarCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            var itemRet = _connector.Consultar((f) => f.GetFiltroKey());

            vm.SetModel(itemRet);
        }
    }

    public class AbstractSalvarCommand : AbstractConnectorCommand, IAbstractSalvarCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            _connector.Salvar(vm.Model);
        }
    }

    public class AbstractExcluirCommand : AbstractConnectorCommand, IAbstractExcluirCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            _connector.Excluir(vm.Model);

            vm.ClearModel();
        }
    }

    public class AbstractExportarCommand  : AbstractCommand, IAbstractExportarCommand
    {
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }

    public class AbstractImportarCommand  : AbstractCommand, IAbstractImportarCommand
    {
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }

    public class AbstractImprimirCommand  : AbstractCommand, IAbstractImprimirCommand
    {
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}