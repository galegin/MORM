using System;

namespace MORM.Dtos.Atributos
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