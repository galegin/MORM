using MORM.CrossCutting;
using System;
using System.Collections.Generic;

namespace MORM.Servico
{
    public class AbstractService : IAbstractService
    {
        private readonly IAbstractRepository _abstractRepository;

        public AbstractService(IAbstractRepository abstractRepository)
        {
            _abstractRepository = abstractRepository ?? throw new ArgumentNullException(nameof(abstractRepository));
        }
    }

    public class AbstractAmbService : IAbstractAmbService
    {
        private readonly IAmbiente _ambiente;

        public AbstractAmbService(IAmbiente ambiente)
        {
            _ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }

    public class AbstractService<TObject> : AbstractService, IAbstractService<TObject>
    {
        private IAbstractRepository<TObject> _repository;

        public AbstractService(IAbstractRepository<TObject> repository) : base(repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //-- listar

        public IList<TObject> Listar(TObject filtro) => _repository.Listar(filtro);

        //-- consultar

        public TObject Consultar(TObject filtro) => _repository.Consultar(filtro);

        //-- incluir

        public void Incluir(TObject objeto) => _repository.Incluir(objeto);

        //-- alterar

        public void Alterar(TObject objeto) => _repository.Alterar(objeto);

        //-- salvar

        public void Salvar(TObject objeto) => _repository.Salvar(objeto);

        //-- excluir

        public void Excluir(TObject objeto) => _repository.Excluir(objeto);

        //-- sequencia

        public long Sequencia(TObject filtro) => _repository.Sequenciar(filtro);
    }
}