using MORM.Apresentacao.Comps;
using MORM.CrossCutting;

namespace MORM.Apresentacao.Connectors
{
    public abstract class AbstractConnector
    {
        public void ExibirMensagem(string mensagem, bool isGerarLog = false, bool isGerarExcecao = false)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                return;

            if (isGerarLog)
                Logger.Info(mensagem);

            if (isGerarExcecao)
                throw new ExceptionInfo(mensagem);

            TelaUtils.Instance.MainMensagem.MensagemErro(mensagem);
        }
    }

    public abstract class AbstractConnector<TEntrada, TRetorno> : AbstractConnector
        where TEntrada : class
        where TRetorno : class
    {
        protected bool IsContemServico => ServiceAssembly.IsContemServico();

        public virtual TRetorno Executar(TEntrada instance, object filtro = null)
        {
            if (IsContemServico)
            {
                return ServiceAssembly.Execute<TEntrada, TRetorno>(this.GetMtd(), instance, this);
            }

            var consumerApi = new AbstractApiConsumer<TEntrada, TRetorno>();
            var retorno = consumerApi.Post(instance, instance.GetApi(mtdPadrao: this.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
            return retorno.Conteudo;
        }
    }
}