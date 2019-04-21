using System.Collections.Generic;

namespace MORM.Dtos.Classes
{
    public abstract class AbstractValidator
    {
        public abstract void Validate();
    }

    public abstract class AbstractValidator<TObj> : AbstractValidator
    {
        private readonly TObj _instance;

        public AbstractValidator(TObj instance)
        {
            _instance = instance;
        }
    }

    public abstract class AbstractValidatorList
    {
        private readonly List<AbstractValidator> _validators =
            new List<AbstractValidator>();

        public AbstractValidatorList()
        {
        }

        protected void Clear()
        {
            _validators.Clear();
        }

        protected void Add(AbstractValidator validator)
        {
            _validators.Add(validator);
        }

        public virtual void Validate()
        {
            _validators.ForEach(validator =>
            {
                validator.Validate();
            });
        }
    }
}