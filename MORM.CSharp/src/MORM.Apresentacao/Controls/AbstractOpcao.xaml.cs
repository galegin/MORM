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

        public AbstractOpcao(IAbstractViewModel vm, ICommand[] commands) : this()
        {
            DataContext = vm;
            CreateComps(commands);
        }

        public void CreateComps(ICommand[] commands)
        {
            stkOpcao.Children.Clear();

            if (commands == null)
                return;

            var style = FindResource("DefaultButton") as Style;

            foreach (var command in commands)
            {
                var content = command.GetType().Name
                    .Replace("TelaAnterior", "")
                    .Replace("Tela`1", "");
                var name = $"Button{content}";
                var button = new AbstractButton()
                {
                    Content = content,
                    Command = command,
                    CommandParameter = DataContext,
                    Style = style,
                    Name = name,
                };
                stkOpcao.Children.Add(button);
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