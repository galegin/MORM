using MORM.Dominio.Extensoes;
using System.Collections.Generic;

namespace MORM.Dtos.Classes
{
    public abstract class AbstractValidator
    {
        public abstract void Validate();

        protected bool IsEmpty(object value) => value?.IsEmpty() ?? true;
    }

    public abstract class AbstractValidator<TInstance> : AbstractValidator
    {
        protected readonly TInstance _instance;

        public AbstractValidator(TInstance instance) => _instance = instance;
    }
    
    public abstract class AbstractValidatorList<TInstance>
    {
        private readonly List<AbstractValidator<TInstance>> _validators =
            new List<AbstractValidator<TInstance>>();

        public AbstractValidatorList(TInstance instance) { }

        protected void Add(AbstractValidator<TInstance> validator) => _validators.Add(validator);

        public virtual void Validate() => _validators.ForEach(validator => validator.Validate());
    }
    
    public static class AbstractValidatorExtension
    {
        public static bool IsEmpty<TValue>(this TValue value)
        {
            if (value == null)
                return true;

            if (typeof(TValue).IsBool())
                return false;

            var valueNull = typeof(TValue).GetValueNull();
            if (valueNull.Equals(value))
                return true;

            return false;
        }
    }
}