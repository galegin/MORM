using MORM.Apresentacao.Controls;
using MORM.Infra.CrossCutting;
using System.Reflection;
using System.Windows.Data;

namespace MORM.Apresentacao.Views
{
    public static class BindingExtensions
    {
        public static Binding GetDataBinding(this PropertyInfo prop, AbstractSource source, string pathBinding = null)
        {
            return new Binding(pathBinding ?? $"{source.Nome}.{prop.Name}")
            {
                Source = source.Source,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                StringFormat = prop.GetFormato(),
            };
        }
    }
}