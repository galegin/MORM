using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public class AbstractScrollViewer : ScrollViewer
    {
        #region construtores
        public AbstractScrollViewer()
        {
            Margin = new Thickness(10);
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            CanContentScroll = true;
        }
        #endregion
    }
}