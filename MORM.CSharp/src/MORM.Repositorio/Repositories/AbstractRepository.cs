using MORM.Repositorio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Repositorio.Repositories
{
    //-- galeg - 01/05/2018 11:37:48
    public class AbstractRepository : IAbstractRepository
    {
        public AbstractRepository(IDataContext context)
        {
            DataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IDataContext DataContext { get; }
    }

    public class AbstractRepository<TObject> : AbstractRepository, IAbstractRepository<TObject> where TObject : class
    {
        public AbstractRepository(IDataContext context) : base(context)
        {
        }

        // listar

        public IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0)
        {
            return DataContext.GetListaF(filtro, qtde: qtde, pagina: pagina);
        }

        public IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0)
        {
            return DataContext.GetListaO<TObject>(objeto, qtde: qtde, pagina: pagina);
        }

        public IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0)
        {
            return DataContext.GetListaW<TObject>(where, qtde: qtde, pagina: pagina);
        }

        // consultar

        public TObject ConsultarF(Func<TObject, string> filtro)
        {
            return DataContext.GetObjetoF(filtro);
        }

        public TObject ConsultarO(object objeto)
        {
            return DataContext.GetObjetoO<TObject>(objeto);
        }

        public TObject ConsultarW(string where)
        {
            return DataContext.GetObjetoW<TObject>(where);
        }

        // incluir

        public void Incluir(IList<TObject> lista)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.InsLista(lista as IList);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Incluir(TObject objeto)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.InsObjeto(objeto);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // alterar

        public void Alterar(IList<TObject> lista)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.UpdLista(lista as IList);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Alterar(TObject objeto)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.UpdObjeto(objeto);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // salvar

        public void Salvar(IList<TObject> lista)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.SetLista(lista as IList);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Salvar(TObject objeto)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.SetObjeto(objeto);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // excluir

        public void Excluir(IList<TObject> lista)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.RemLista(lista as IList);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Excluir(TObject objeto)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.RemObjeto(objeto);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // sequencia

        public int SequenciaGen()
        {
            return DataContext.GetSequenciaGen<TObject>();
        }

        public int SequenciaMaxF(Func<TObject, string> filtro)
        {
            return DataContext.GetSequenciaMaxF(filtro);
        }

        public int SequenciaMaxO(object objeto)
        {
            return DataContext.GetSequenciaMaxO<TObject>(objeto);
        }

        public int SequenciaMaxW(string where)
        {
            return DataContext.GetSequenciaMaxW<TObject>(where);
        }
    }
}