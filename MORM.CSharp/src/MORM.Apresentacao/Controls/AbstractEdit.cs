using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Controls
{
    public class AbstractEdit : TextBox
    {
        #region Variaveis
        private AbstractEditTipo _tipo;
        #endregion

        #region Construtores
        public AbstractEdit(AbstractEditTipo tipo)
        {
            SetTipo(_tipo);
            PreviewTextInput += AbstractEdit_PreviewTextInput;
            GotFocus += AbstractEdit_GotFocus;
            LostFocus += AbstractEdit_LostFocus;
        }
        public AbstractEdit() : this(AbstractEditTipo.Texto)
        {
        }
        #endregion

        #region Properties
        private void SetTipo(AbstractEditTipo tipo)
        {
            _tipo = tipo;
            _regex = new Regex(_tipo.GetValidacao());
        }
        public AbstractEditTipo Tipo
        {
            get => _tipo;
            set => SetTipo(value);
        }
        new public string Text
        {
            get => _tipo.GetFormatValue(base.Text);
            set => base.Text = _tipo.GetFormatValue(value?.ToString());
        }
        public object Value
        {
            get => _tipo.GetValue(base.Text);
            set => base.Text = _tipo.GetFormatValue(value?.ToString());
        }
        #endregion

        #region Functions
        private Regex _regex; //regex that matches disallowed text
        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        #endregion

        #region Event Functions
        private void AbstractEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        protected void AbstractEdit_GotFocus(object sender, RoutedEventArgs e)
        {
            base.SelectAll();
        }
        protected void AbstractEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            var value = _tipo.GetFormatValue(base.Text);
            base.Text = !string.IsNullOrWhiteSpace(value) ? value : string.Empty;
        }
        #endregion
    }

    #region comps

    public class AbstractEditData : AbstractEdit
    {
        public AbstractEditData() : base(AbstractEditTipo.Data) { }
    }

    public class AbstractEditDataHora : AbstractEdit
    {
        public AbstractEditDataHora() : base(AbstractEditTipo.DataHora) { }
    }

    public class AbstractEditDataHoraSegundo : AbstractEdit
    {
        public AbstractEditDataHoraSegundo() : base(AbstractEditTipo.DataHoraSegundo) { }
    }

    public class AbstractEditDataRef : AbstractEdit
    {
        public AbstractEditDataRef() : base(AbstractEditTipo.DataRef) { }
    }

    public class AbstractEditDataAno : AbstractEdit
    {
        public AbstractEditDataAno() : base(AbstractEditTipo.DataAno) { }
    }

    public class AbstractEditHora : AbstractEdit
    {
        public AbstractEditHora() : base(AbstractEditTipo.Hora) { }
    }

    public class AbstractEditHoraSegundo : AbstractEdit
    {
        public AbstractEditHoraSegundo() : base(AbstractEditTipo.HoraSegundo) { }
    }

    public class AbstractEditNumero : AbstractEdit
    {
        public AbstractEditNumero() : base(AbstractEditTipo.Numero) { }
    }

    public class AbstractEditTexto : AbstractEdit
    {
        public AbstractEditTexto() : base(AbstractEditTipo.Texto) { }
    }

    public class AbstractEditValor : AbstractEdit
    {
        public AbstractEditValor() : base(AbstractEditTipo.Valor) { }
    }

    #endregion 
}