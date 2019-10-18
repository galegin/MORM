using MORM.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Repositorio
{
    public class AbstractRepository : IAbstractRepository
    {
        protected readonly IAbstractDataContext _dataContext;

        public AbstractRepository(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }

    public class AbstractRepository<TObject> : AbstractRepository, IAbstractRepository<TObject>
    {
        public IDbSet<TObject> DbSet { get; }

        public AbstractRepository(IAbstractDataContext context) : base(context)
        {
            DbSet = context.Set<TObject>();
        }

        // listar

        public IList<TObject> Listar(object filtro = null, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return _dataContext.GetLista(typeof(TObject), filtro: filtro, qtde: qtde, pagina: pagina, relacao: relacao) 
                as IList<TObject>;
        }

        // consultar

        public TObject Consultar(object filtro = null, bool relacao = true)
        {
            return (TObject)_dataContext.GetObjeto(typeof(TObject), filtro: filtro, relacao: relacao);
        }

        // incluir

        public void Incluir(object objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                if (objeto is IList)
                    foreach (var item in (objeto as IList))
                        _dataContext.InsObjeto(item, relacao: relacao);
                else
                    _dataContext.InsObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // alterar

        public void Alterar(object objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                if (objeto is IList)
                    foreach (var item in (objeto as IList))
                        _dataContext.UpdObjeto(item, relacao: relacao);
                else
                    _dataContext.UpdObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // salvar

        public void Salvar(object objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                if (objeto is IList)
                    foreach (var item in (objeto as IList))
                        _dataContext.SetObjeto(item, relacao: relacao);
                else
                    _dataContext.SetObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // excluir

        public void Excluir(object objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                if (objeto is IList)
                    foreach (var item in (objeto as IList))
                        _dataContext.RemObjeto(item, relacao: relacao);
                else
                    _dataContext.RemObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // sequencia
        
        public long Sequenciar(object filtro = null)
        {
            return _dataContext.IncObjeto<TObject>(filtro);
        }
    }
}