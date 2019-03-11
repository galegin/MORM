using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MORM.Apresentacao.Comps
{
    public abstract class AbstractNotifyPropertyChanged : IAbstractNotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void NotifyAllPropertiesChanged()
        {
            GetType().GetProperties().ToList().ForEach(x => NotifyPropertyChanged(x.Name));
        }

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