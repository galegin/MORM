using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractOpcao : AbstractUserControl
    {
        public AbstractOpcao()
        {
            InitializeComponent();
        }

        public AbstractOpcao(IAbstractViewModel vm) : this()
        {
            DataContext = vm;
            CreateComps(vm.Commands);
        }

        public void CreateComps(ICommand[] commands)
        {
            stkOpcao.Children.Clear();

            if (commands == null)
                return;

            var style = FindResource("DefaultButton") as Style;

            foreach (var command in commands)
            {
                stkOpcao.Children.Add(new AbstractButton()
                {
                    Command = command,
                    CommandParameter = DataContext,
                    Content = command.GetDescription(),
                    Name = command.GetNameButton(),
                    Style = style,
                });
            }
        }
    }

    public partial class AbstractOpcao<TViewModel> : AbstractOpcao
        where TViewModel : class
    {
        public AbstractOpcao() : base()
        {
            DataContext = Activator.CreateInstance<TViewModel>();
        }

        public AbstractOpcao(IAbstractViewModel<TViewModel> vm, ICommand[] commands) : base()
        {
            DataContext = vm;
        }
    }
}