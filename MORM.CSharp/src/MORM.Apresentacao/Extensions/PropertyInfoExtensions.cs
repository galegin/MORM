using MORM.Apresentacao.Controls;
using MORM.Dominio.Atributos;
using MORM.Dominio.Extensoes;
using System.Reflection;
using System.Windows.Data;

namespace MORM.Apresentacao.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static string GetDescricao(this PropertyInfo prop)
        {
            var descricao = prop.GetAttribute<DescricaoAttribute>();
            return descricao?.Value ?? prop.Name;
        }

        public static string GetFormato(this PropertyInfo prop)
        {
            var formato = prop.GetAttribute<FormatoAttribute>()?.Conteudo;
            if (string.IsNullOrWhiteSpace(formato))
            {
                var type = prop.PropertyType;

                if (type.IsBool())
                    formato = null;
                else if (type.IsDate())
                    formato = "dd/MM/yyyy";
                else if (type.IsReal())
                {
                    var precisao = prop.GetPrecisao();
                    var precisaoStr = precisao > 0 ? "." + new string('0', precisao) : string.Empty;
                    //formato = $"{{}}{{0:#,##0{precisaoStr}}}";
                    formato = $"#,##0{precisaoStr}";
                }
                else if (type.IsInt())
                    //formato = "{}{0:#,##0}";
                    formato = "#,##0";
                else if (type.IsStr())
                    formato = null;
            }

            return formato;
        }

        public static int GetTamanho(this PropertyInfo prop)
        {
            var tamanho = prop.GetAttribute<TamanhoAttribute>()?.Value ?? 0;
            if (tamanho == 0)
            {
                var type = prop.PropertyType;

                if (type.IsBool())
                    tamanho = 10;
                else if (type.IsDate())
                    tamanho = 10;
                else if (type.IsReal())
                    tamanho = 10;
                else if (type.IsInt())
                    tamanho = 10;
                else if (type.IsStr())
                    tamanho = 50;
            }

            return tamanho;
        }

        public static int GetPrecisao(this PropertyInfo prop)
        {
            var precisao = prop.GetAttribute<TamanhoAttribute>()?.Value ?? 0;
            if (precisao == 0)
            {
                var type = prop.PropertyType;

                if (type.IsBool())
                    precisao = 0;
                else if (type.IsDate())
                    precisao = 0;
                else if (type.IsReal())
                    precisao = 2;
                else if (type.IsInt())
                    precisao = 0;
                else if (type.IsStr())
                    precisao = 0;
            }

            return precisao;
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

        public static Binding GetDataBinding(this PropertyInfo prop, object source, string path)
        {
            var binding = new Binding($"{path}.{prop.Name}");
            binding.Source = source;
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.StringFormat = prop.GetFormato();
            return binding;
        }
    }
}