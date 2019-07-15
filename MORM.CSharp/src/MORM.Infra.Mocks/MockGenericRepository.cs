using MORM.Dominio.Interfaces;
using MORM.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Infra.Mocks
{
    public class MockGenericRepository<TObject> : IAbstractRepository<TObject>
        where TObject : class
    {
        public IAbstractDataContext DataContext { get; }

        public MockGenericRepository(IAbstractDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //-- queryable

        public IQueryableObject<TObject> AsQueryable()
        {
            return new QueryableObject<TObject>(DataContext);
        }

        //-- listar

        public IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            var lista = new List<TObject>();
            DataContext.GetLista(lista, where: null, qtde: qtde, pagina: pagina, relacao: relacao);
            return lista;
        }

        public IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return ListarF(null, qtde: qtde, pagina: pagina, relacao: relacao);
        }

        public IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return ListarF(null, qtde: qtde, pagina: pagina, relacao: relacao);
        }

        //-- consultar

        public TObject ConsultarF(Func<TObject, string> filtro, bool relacao = true)
        {
            var objeto = Activator.CreateInstance<TObject>();
            DataContext.GetObjeto(objeto, relacao: relacao);
            return objeto;
        }

        public TObject ConsultarO(object objeto, bool relacao = true)
        {
            return ConsultarF(null, relacao: relacao);
        }

        public TObject ConsultarW(string where, bool relacao = true)
        {
            return ConsultarF(null, relacao: relacao);
        }

        //-- incluir

        public void Incluir(IList<TObject> lista, bool relacao = true)
        {
            lista.ToList().ForEach(item => Incluir(item));
        }

        public void Incluir(TObject objeto, bool relacao = true)
        {
            DataContext.InsObjeto(objeto);
        }

        //-- alterar

        public void Alterar(IList<TObject> lista, bool relacao = true)
        {
            lista.ToList().ForEach(item => Alterar(item));
        }

        public void Alterar(TObject objeto, bool relacao = true)
        {
            DataContext.UpdObjeto(objeto);
        }

        //-- salvar

        public void Salvar(IList<TObject> lista, bool relacao = true)
        {
            lista.ToList().ForEach(item => Salvar(item));
        }

        public void Salvar(TObject objeto, bool relacao = true)
        {
            DataContext.SetObjeto(objeto);
        }

        //-- excluir

        public void Excluir(IList<TObject> lista, bool relacao = true)
        {
            lista.ToList().ForEach(item => Excluir(item));
        }

        public void Excluir(TObject objeto, bool relacao = true)
        {
            DataContext.RemObjeto(objeto);
        }

        //-- gatilhos

        public void posAlterar(TObject objeto) { }
        public void posExcluir(TObject objeto) { }
        public void posIncluir(TObject objeto) { }
        public void posSalvar(TObject objeto) { }
        public void preAlterar(TObject objeto) { }
        public void preExcluir(TObject objeto) { }
        public void preIncluir(TObject objeto) { }
        public void preSalvar(TObject objeto) { }

        //-- sequencia

        public int SequenciaGen()
        {
            return ListarF(null).Count + 1;
        }

        public int SequenciaMaxF(Func<TObject, string> filtro)
        {
            return SequenciaGen();
        }

        public int SequenciaMaxO(object objeto)
        {
            return SequenciaGen();
        }

        public int SequenciaMaxW(string where)
        {
            return SequenciaGen();
        }
    }
}