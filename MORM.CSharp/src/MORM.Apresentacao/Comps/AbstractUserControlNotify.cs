using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace MORM.Apresentacao.Comps
{
    public class AbstractUserControlNotify : UserControl, IAbstractUserControlNotify
    {
        //-- DataContext

        protected void SetDataContext()
        {
            DataContext = null;
            DataContext = this;
        }

        //-- PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyAllPropertiesChanged()
        {
            GetType().GetProperties().ToList().ForEach(x => NotifyPropertyChanged(x.Name));
        }

        //-- SetField        

        public void SetField<TObject>(ref TObject field, TObject value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<TObject>.Default.Equals(field, value))
            {
                field = value;
                NotifyPropertyChanged(propertyName);
            }
        }
    }
}