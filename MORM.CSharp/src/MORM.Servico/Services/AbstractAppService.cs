using MORM.CrossCutting;
using MORM.Dominio.Interfaces;
using System;
using System.Linq;

namespace MORM.Servico.Services
{
    public class AbstractAppService : IAbstractAppService
    {
        private IRepository _repository;
        private IRepositoryDataContext _repositoryDataContext => 
            _repository as IRepositoryDataContext;

        public AbstractAppService(IRepository repository)
        {
            _repository = repository;
        }

        public void SetAmbiente(IAmbiente ambiente) => 
            _repositoryDataContext?.DataContext?.SetAmbiente(ambiente);
    }

    public class AbstractAmbAppService : IAbstractAmbAppService
    {
        public IAmbiente Ambiente { get; }

        public AbstractAmbAppService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }

    public class AbstractAppService<TObject> : AbstractAppService, IAbstractAppService<TObject> 
        where TObject : class
    {
        private readonly IRepository<TObject> _repository;

        public AbstractAppService(IRepository<TObject> repository) : base(repository)
        {
            _repository = repository;
        }

        //-- listar

        public object Listar(TObject filtro)
        {
            return _repository
                .GetAll()
                .SetFiltroQueryable(filtro)
                .ToList()
                ;
        }

        //-- consultar

        public object Consultar(TObject filtro)
        {
            return _repository
                .GetAll()
                .SetFiltroQueryable(filtro)
                .FirstOrDefault()
                ;
        }

        //-- incluir

        public object Incluir(TObject objeto)
        {
            _repository.Add(objeto); return null;
        }

        //-- alterar

        public object Alterar(TObject objeto)
        {
            _repository.Update(objeto); return null;
        }

        //-- salvar

        public object Salvar(TObject objeto)
        {
            _repository.AddOrUpdate(objeto); return null;
        }

        //-- excluir

        public object Excluir(TObject objeto)
        {
            _repository.Delete(objeto); return null;
        }

        //-- sequencia

        public object Sequencia(TObject filtro)
        {
            return _repository.Sequencia(filtro);
        }
    }
}