using MORM.Dtos;

namespace MORM.Apresentacao.Consumers
{
    public class AbstractConsumer<TObject> where TObject : class
    {
        public static string Site { get; set; }
        public static string Token { get; set; }

        public class Listar : AbstractApiConsumer<AbstractDto<TObject>.Listar, AbstractDto<TObject>.ListarRet>
        {
            public Listar() : base(Site, Token)
            {
            }
        }

        public class Consultar : AbstractApiConsumer<AbstractDto<TObject>.Consultar, AbstractDto<TObject>.ConsultarRet>
        {
            public Consultar() : base(Site, Token)
            {
            }
        }

        public class Incluir : AbstractApiConsumer<AbstractDto<TObject>.Incluir, object>
        {
            public Incluir() : base(Site, Token)
            {
            }
        }

        public class IncluirLista : AbstractApiConsumer<AbstractDto<TObject>.IncluirLista, object>
        {
            public IncluirLista() : base(Site, Token)
            {
            }
        }

        public class Alterar : AbstractApiConsumer<AbstractDto<TObject>.Alterar, object>
        {
            public Alterar() : base(Site, Token)
            {
            }
        }

        public class AlterarLista : AbstractApiConsumer<AbstractDto<TObject>.AlterarLista, object>
        {
            public AlterarLista() : base(Site, Token)
            {
            }
        }

        public class Salvar : AbstractApiConsumer<AbstractDto<TObject>.Salvar, object>
        {
            public Salvar() : base(Site, Token)
            {
            }
        }

        public class SalvarLista : AbstractApiConsumer<AbstractDto<TObject>.SalvarLista, object>
        {
            public SalvarLista() : base(Site, Token)
            {
            }
        }

        public class Excluir : AbstractApiConsumer<AbstractDto<TObject>.Excluir, object>
        {
            public Excluir() : base(Site, Token)
            {
            }
        }

        public class ExcluirLista : AbstractApiConsumer<AbstractDto<TObject>.ExcluirLista, object>
        {
            public ExcluirLista() : base(Site, Token)
            {
            }
        }
    }
}