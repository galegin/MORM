using MORM.Apresentacao.Consumers;
using MORM.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractConnector<TObject> where TObject : class
    {
        private static string _site = ConfigurationManager.AppSettings[nameof(_site)] ?? "http://localhost";
        private static string _token = ConfigurationManager.AppSettings[nameof(_token)] ?? "123456";

        static AbstractConnector()
        {
            AbstractConsumer<TObject>.Site = _site; // ?????
            AbstractConsumer<TObject>.Token = _token; // ?????
        }

        public AbstractConnector()
        {
            AbstractConsumer = new AbstractConsumer<TObject>();
        }
        
        public AbstractConsumer<TObject> AbstractConsumer { get; }

        private AbstractConsumer<TObject>.Listar _listar = new AbstractConsumer<TObject>.Listar();
        private AbstractConsumer<TObject>.Consultar _consultar = new AbstractConsumer<TObject>.Consultar();

        private AbstractConsumer<TObject>.Incluir _incluir = new AbstractConsumer<TObject>.Incluir();
        private AbstractConsumer<TObject>.IncluirLista _incluirLista = new AbstractConsumer<TObject>.IncluirLista();

        private AbstractConsumer<TObject>.Alterar _alterar = new AbstractConsumer<TObject>.Alterar();
        private AbstractConsumer<TObject>.AlterarLista _alterarLista = new AbstractConsumer<TObject>.AlterarLista();

        private AbstractConsumer<TObject>.Salvar _salvar = new AbstractConsumer<TObject>.Salvar();
        private AbstractConsumer<TObject>.SalvarLista _salvarLista = new AbstractConsumer<TObject>.SalvarLista();

        private AbstractConsumer<TObject>.Excluir _excluir = new AbstractConsumer<TObject>.Excluir();
        private AbstractConsumer<TObject>.ExcluirLista _excluirLista = new AbstractConsumer<TObject>.ExcluirLista();

        public IList<TObject> Listar(Func<TObject, string> filtro)
        {
            return _listar.Post(new AbstractDto<TObject>.Listar(filtro))?.Conteudo?.Lista;
        }

        public TObject Consultar(Func<TObject, string> filtro)
        {
            return _consultar.Post(new AbstractDto<TObject>.Consultar(filtro))?.Conteudo?.Objeto;
        }

        // incluir

        public void Incluir(IList<TObject> lista)
        {
            _incluirLista.Post(new AbstractDto<TObject>.IncluirLista(lista));
        }

        public void Incluir(TObject objeto)
        {
            _incluir.Post(new AbstractDto<TObject>.Incluir(objeto));
        }

        // alterar

        public void Alterar(IList<TObject> lista)
        {
            _alterarLista.Post(new AbstractDto<TObject>.AlterarLista(lista));
        }

        public void Alterar(TObject objeto)
        {
            _alterar.Post(new AbstractDto<TObject>.Alterar(objeto));
        }

        // salvar

        public void Salvar(IList<TObject> lista)
        {
            _salvarLista.Post(new AbstractDto<TObject>.SalvarLista(lista));
        }

        public void Salvar(TObject objeto)
        {
            _salvar.Post(new AbstractDto<TObject>.Salvar(objeto));
        }

        // excluir

        public void Excluir(IList<TObject> lista)
        {
            _excluirLista.Post(new AbstractDto<TObject>.ExcluirLista(lista));
        }

        public void Excluir(TObject objeto)
        {
            _excluir.Post(new AbstractDto<TObject>.Excluir(objeto));
        }
    }
}