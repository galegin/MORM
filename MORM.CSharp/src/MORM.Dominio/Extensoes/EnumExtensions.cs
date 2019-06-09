using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace MORM.Dominio.Extensoes
{
    //-- miguel - 2/6/2018 9:20:20 AM ; ???
    
    /*
    
    Enum
        public enum TipoBloqueio
        {
            Liberado = 0,
            Bloqueado = 1,
        }
    
    xml
    
        <ComboBox x:Name="cmbBloqueio" Width="300"
                  ItemsSource="{Binding ListaDeTipoBloqueio}" SelectedValue="{Binding TipoBloqueio}" 
                  DisplayMemberPath="Name" SelectedValuePath="Value" />

    UserControl
    
        public IEnumerable<object> ListaDeTipoBloqueio =>
            EnumExtensions.GetEnum<UsuarioBloqueio>();

        public string TipoBloqueio
        {
            get { return Usuario.Bloqueio.ToString(); }
            set { Usuario.Bloqueio = (UsuarioBloqueio)Enum.Parse(typeof(UsuarioBloqueio), value); }
        }
        
    */

    public static class EnumExtensions
    {
        // enumerable

        public static IEnumerable<object> GetEnum<TEnum>()
        {
            var type = typeof(TEnum);
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);
            var pairs =
                Enumerable.Range(0, names.Length)
                .Select(i => new
                {
                    Name = GetAtributeEnum<TEnum, DescriptionAttribute>(names.GetValue(i).ToString())?.Description ?? names.GetValue(i),
                    Value = GetAtributeEnum<TEnum, XmlEnumAttribute>(values.GetValue(i).ToString())?.Name ?? values.GetValue(i),
                })
                .OrderBy(pair => pair.Name);
            return pairs;
        }

        // attribute

        public static TAbtrib GetAtributeAttr<TEnum, TAbtrib>(this TEnum enumValue)
            where TAbtrib : Attribute
        {
            var enumType = enumValue.GetType().GetMember(enumValue.ToString());
            var atrib = (TAbtrib)enumType.FirstOrDefault()?
                .GetCustomAttributes(typeof(TAbtrib), false).FirstOrDefault();
            return atrib;
        }

        public static TAbtrib GetAtributeEnum<TEnum, TAbtrib>(string name)
            where TAbtrib : Attribute
        {
            var enumValue = (TEnum)Enum.Parse(typeof(TEnum), name);
            var enumType = enumValue.GetType().GetMember(name);
            var atrib = (TAbtrib)enumType.FirstOrDefault()?
                .GetCustomAttributes(typeof(TAbtrib), false).FirstOrDefault();
            return atrib;
        }

        // enum from value

        public static TEnum GetEnumFromValue<TEnum>(string value)
        {
            var enumName = (TEnum)Enum.Parse(typeof(TEnum), "-1");

            foreach (var name in Enum.GetNames(typeof(TEnum)))
            {
                enumName = (TEnum)Enum.Parse(typeof(TEnum), name);
                if (GetValueFromEnum(enumName) == value)
                    return enumName;
            }

            return enumName;
        }

        // description

        public static string GetDescriptionFromEnum<TEnum>(this TEnum value)
        {
            var enumStr = string.Empty;

            enumStr = GetAtributeEnum<TEnum, DescriptionAttribute>(value.ToString())?.Description ?? value.ToString();

            return enumStr;
        }

        // value

        public static string GetValueFromEnum<TEnum>(this TEnum value)
        {
            var enumStr = string.Empty;

            enumStr = GetAtributeEnum<TEnum, XmlEnumAttribute>(value.ToString())?.Name ?? value.ToString();

            return enumStr;
        }

        // contains

        public static bool In<TEnun>(this TEnun enun, params TEnun[] enuns)
        {
            return enuns.Contains(enun);
        }
    }
}