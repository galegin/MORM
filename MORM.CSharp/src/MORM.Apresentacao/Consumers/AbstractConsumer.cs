using MORM.Utilidade.Dtos;

namespace MORM.Apresentacao.Consumers
{
    public class AbstractConsumer<TObject> where TObject : class
    {
        public static string Site { get; set; }
        public static string Token { get; set; }

        public class Listar : AbstractApiConsumer<DtoAbstract<TObject>.Listar, DtoAbstract<TObject>.ListarRet>
        {
            public Listar() : base(Site, Token)
            {
            }
        }

        public class Consultar : AbstractApiConsumer<DtoAbstract<TObject>.Consultar, DtoAbstract<TObject>.ConsultarRet>
        {
            public Consultar() : base(Site, Token)
            {
            }
        }

        public class Incluir : AbstractApiConsumer<DtoAbstract<TObject>.Incluir, object>
        {
            public Incluir() : base(Site, Token)
            {
            }
        }

        public class IncluirLista : AbstractApiConsumer<DtoAbstract<TObject>.IncluirLista, object>
        {
            public IncluirLista() : base(Site, Token)
            {
            }
        }

        public class Alterar : AbstractApiConsumer<DtoAbstract<TObject>.Alterar, object>
        {
            public Alterar() : base(Site, Token)
            {
            }
        }

        public class AlterarLista : AbstractApiConsumer<DtoAbstract<TObject>.AlterarLista, object>
        {
            public AlterarLista() : base(Site, Token)
            {
            }
        }

        public class Salvar : AbstractApiConsumer<DtoAbstract<TObject>.Salvar, object>
        {
            public Salvar() : base(Site, Token)
            {
            }
        }

        public class SalvarLista : AbstractApiConsumer<DtoAbstract<TObject>.SalvarLista, object>
        {
            public SalvarLista() : base(Site, Token)
            {
            }
        }

        public class Excluir : AbstractApiConsumer<DtoAbstract<TObject>.Excluir, object>
        {
            public Excluir() : base(Site, Token)
            {
            }
        }

        public class ExcluirLista : AbstractApiConsumer<DtoAbstract<TObject>.ExcluirLista, object>
        {
            public ExcluirLista() : base(Site, Token)
            {
            }
        }
    }
}