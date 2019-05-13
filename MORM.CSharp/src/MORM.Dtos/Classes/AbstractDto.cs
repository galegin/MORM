using MORM.Dtos.Classes;

namespace MORM.Dtos
{
    public abstract class AbstractDto
    {
    }
    
    public abstract class AbstractDto<TInstance> : AbstractDto 
    {
    }

    public abstract class AbstractDto<TEntrada, TRetorno> : AbstractDto 
        where TEntrada : class
    {
        public class Envio
        {
            public TEntrada Instance { get; set; }

            public Envio() { }
            public Envio(TEntrada instance) => Instance = instance;
        }

        public class Retorno
        {
            public TRetorno Instance { get; set; }

            public Retorno() { }
            public Retorno(TRetorno instance) => Instance = instance;
        }

        public class Validation : AbstractValidator<TEntrada>
        {
            public Validation(TEntrada instance) : base(instance) { }

            public override void Validate() { }
        }
    }
}