using MORM.Apresentacao.Comps;
using System;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractTitulo : AbstractUserControlNotify
    {
        #region construtores
        public AbstractTitulo(string titulo)
        {
            InitializeComponent();
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            DataContext = this;
        }
        #endregion

        #region variaveis
        public string _titulo;
        #endregion

        #region propriedades
        public string Titulo
        {
            get => _titulo;
            set => SetField(ref _titulo, value);
        }
        #endregion
    }
}