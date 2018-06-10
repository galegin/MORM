using MORM.Apresentacao.Consumers;
using MORM.Utilidade.Dtos;
using MORM.Utilidade.Factories;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractConnector<TObject> where TObject: class
    {
        public AbstractConnector()
        {
            AbstractConsumer = new AbstractConsumer<TObject>();
        }
        
        public AbstractConsumer<TObject> AbstractConsumer { get; }

        private AbstractConsumer<TObject>.Listar _listar 
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.Listar>();
        private AbstractConsumer<TObject>.Consultar _consultar
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.Consultar>();

        private AbstractConsumer<TObject>.Incluir _incluir
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.Incluir>();
        private AbstractConsumer<TObject>.IncluirLista _incluirLista
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.IncluirLista>();

        private AbstractConsumer<TObject>.Alterar _alterar
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.Alterar>();
        private AbstractConsumer<TObject>.AlterarLista _alterarLista
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.AlterarLista>();

        private AbstractConsumer<TObject>.Salvar _salvar
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.Salvar>();
        private AbstractConsumer<TObject>.SalvarLista _salvarLista
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.SalvarLista>();

        private AbstractConsumer<TObject>.Excluir _excluir
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.Excluir>();
        private AbstractConsumer<TObject>.ExcluirLista _excluirLista
            => SingletonFactory.GetInstance<AbstractConsumer<TObject>.ExcluirLista>();

        public IList<TObject> Listar(Func<TObject, string> filtro)
        {
            return _listar.Post(new DtoAbstract<TObject>.Listar(filtro)).Lista;
        }

        public TObject Consultar(Func<TObject, string> filtro)
        {
            return _consultar.Post(new DtoAbstract<TObject>.Consultar(filtro)).Objeto;
        }

        // incluir

        public void Incluir(IList<TObject> lista)
        {
            _incluirLista.Post(new DtoAbstract<TObject>.IncluirLista(lista));
        }

        public void Incluir(TObject objeto)
        {
            _incluir.Post(new DtoAbstract<TObject>.Incluir(objeto));
        }

        // alterar

        public void Alterar(IList<TObject> lista)
        {
            _alterarLista.Post(new DtoAbstract<TObject>.AlterarLista(lista));
        }

        public void Alterar(TObject objeto)
        {
            _alterar.Post(new DtoAbstract<TObject>.Alterar(objeto));
        }

        // salvar

        public void Salvar(IList<TObject> lista)
        {
            _salvarLista.Post(new DtoAbstract<TObject>.SalvarLista(lista));
        }

        public void Salvar(TObject objeto)
        {
            _salvar.Post(new DtoAbstract<TObject>.Salvar(objeto));
        }

        // excluir

        public void Excluir(IList<TObject> lista)
        {
            _excluirLista.Post(new DtoAbstract<TObject>.ExcluirLista(lista));
        }

        public void Excluir(TObject objeto)
        {
            _excluir.Post(new DtoAbstract<TObject>.Excluir(objeto));
        }
    }
}