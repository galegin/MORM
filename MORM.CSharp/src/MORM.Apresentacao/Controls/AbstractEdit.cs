using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Controls
{
    public class AbstractEdit : TextBox
    {
        #region Variaveis
        private AbstractCampoFormato _formato;
        #endregion

        #region Construtores
        public AbstractEdit(AbstractCampoFormato tipo)
        {
            SetTipo(_formato);
            PreviewTextInput += AbstractEdit_PreviewTextInput;
            GotFocus += AbstractEdit_GotFocus;
            LostFocus += AbstractEdit_LostFocus;
        }
        public AbstractEdit() : this(AbstractCampoFormato.Texto)
        {
        }
        #endregion

        #region Properties
        private void SetTipo(AbstractCampoFormato tipo)
        {
            _formato = tipo;
            _regex = new Regex(_formato.GetValidacao());
        }
        public AbstractCampoFormato Formato
        {
            get => _formato;
            set => SetTipo(value);
        }
        new public string Text
        {
            get => _formato.GetFormatValue(base.Text);
            set => base.Text = _formato.GetFormatValue(value?.ToString());
        }
        public object Value
        {
            get => _formato.GetValue(base.Text);
            set => base.Text = _formato.GetFormatValue(value?.ToString());
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
            var value = _formato.GetFormatValue(base.Text);
            base.Text = !string.IsNullOrWhiteSpace(value) ? value : string.Empty;
        }
        #endregion
    }

    #region comps

    public class AbstractEditData : AbstractEdit
    {
        public AbstractEditData() : base(AbstractCampoFormato.Data) { }
    }

    public class AbstractEditDataHora : AbstractEdit
    {
        public AbstractEditDataHora() : base(AbstractCampoFormato.DataHora) { }
    }

    public class AbstractEditDataHoraSegundo : AbstractEdit
    {
        public AbstractEditDataHoraSegundo() : base(AbstractCampoFormato.DataHoraSegundo) { }
    }

    public class AbstractEditDataRef : AbstractEdit
    {
        public AbstractEditDataRef() : base(AbstractCampoFormato.DataRef) { }
    }

    public class AbstractEditDataAno : AbstractEdit
    {
        public AbstractEditDataAno() : base(AbstractCampoFormato.DataAno) { }
    }

    public class AbstractEditHora : AbstractEdit
    {
        public AbstractEditHora() : base(AbstractCampoFormato.Hora) { }
    }

    public class AbstractEditHoraSegundo : AbstractEdit
    {
        public AbstractEditHoraSegundo() : base(AbstractCampoFormato.HoraSegundo) { }
    }

    public class AbstractEditNumero : AbstractEdit
    {
        public AbstractEditNumero() : base(AbstractCampoFormato.Numero) { }
    }

    public class AbstractEditTexto : AbstractEdit
    {
        public AbstractEditTexto() : base(AbstractCampoFormato.Texto) { }
    }

    public class AbstractEditValor : AbstractEdit
    {
        public AbstractEditValor() : base(AbstractCampoFormato.Valor) { }
    }

    #endregion 
}