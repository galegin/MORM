using MORM.Utilidade.Dtos;

namespace MORM.Apresentacao.Consumers
{
    public class AbstractConsumer<TObject> where TObject : class
    {
        public class Listar : ApiConsumer<DtoAbstract<TObject>.Listar, DtoAbstract<TObject>.ListarRet> { }
        public class Consultar : ApiConsumer<DtoAbstract<TObject>.Consultar, DtoAbstract<TObject>.ConsultarRet> { }
        public class Incluir : ApiConsumer<DtoAbstract<TObject>.Incluir, object> { }
        public class IncluirLista : ApiConsumer<DtoAbstract<TObject>.IncluirLista, object> { }
        public class Alterar : ApiConsumer<DtoAbstract<TObject>.Alterar, object> { }
        public class AlterarLista : ApiConsumer<DtoAbstract<TObject>.AlterarLista, object> { }
        public class Salvar : ApiConsumer<DtoAbstract<TObject>.Salvar, object> { }
        public class SalvarLista : ApiConsumer<DtoAbstract<TObject>.SalvarLista, object> { }
        public class Excluir : ApiConsumer<DtoAbstract<TObject>.Excluir, object> { }
        public class ExcluirLista : ApiConsumer<DtoAbstract<TObject>.ExcluirLista, object> { }
    }
}