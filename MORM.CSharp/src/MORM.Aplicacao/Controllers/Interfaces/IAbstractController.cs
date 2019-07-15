using MORM.Servico.Models;
using System.Net.Http;

namespace MORM.Aplicacao.Controllers
{
    public interface IAbstractController<TObject> where TObject : class
    {
        HttpResponseMessage Listar(AbstractListarDto.Envio<TObject> dto);
        HttpResponseMessage Consultar(AbstractConsultarDto.Envio<TObject> dto);
        HttpResponseMessage Incluir(AbstractIncluirDto.Envio<TObject> dto);
        HttpResponseMessage Alterar(AbstractAlterarDto.Envio<TObject> dto);
        HttpResponseMessage Salvar(AbstractSalvarDto.Envio<TObject> dto);
        HttpResponseMessage Excluir(AbstractExcluirDto.Envio<TObject> dto);
        HttpResponseMessage Sequencia(AbstractSequenciaDto.Envio<TObject> dto);
    }
}