using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MORM.Apresentacao.Comps
{
    public interface IAbstractNotifyPropertyChanged : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string propertyName);        
        void NotifyAllPropertiesChanged();
        void SetField<TObject>(ref TObject field, TObject value, [CallerMemberName] string propertyName = null);
    }
}