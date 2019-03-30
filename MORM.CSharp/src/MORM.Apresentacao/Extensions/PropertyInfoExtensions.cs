using MORM.Apresentacao.Controls;
using MORM.Dominio.Extensoes;
using System.Reflection;
using System.Windows.Data;

namespace MORM.Apresentacao.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static string GetDescricao(this PropertyInfo prop)
        {
            return prop.Name;
        }

        public static AbstractEditTipo GetEditTipo(this PropertyInfo prop)
        {
            var type = prop.PropertyType;

            if (type.IsDate())
                return AbstractEditTipo.Data;
            else if (type.IsReal())
                return AbstractEditTipo.Valor;
            else if (type.IsInt())
                return AbstractEditTipo.Numero;

            return AbstractEditTipo.Texto;
        }

        public static Binding GetDataBinding(this PropertyInfo prop, object source)
        {
            var binding = new Binding(prop.Name);
            binding.Source = source;
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            return binding;
        }
    }
}