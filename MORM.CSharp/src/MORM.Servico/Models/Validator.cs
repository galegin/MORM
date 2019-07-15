using System;

namespace MORM.Servico.Models.Atributos
{
    public class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(Type validator)
        {
            Validator = validator;
        }

        public Type Validator { get; private set; }
    }
}