using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Servico.Services
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
        private IAbstractRepository<TObject> _abstractRepository;

        public AbstractService(IAbstractRepository<TObject> abstractRepository) : base(abstractRepository)
        {
            _abstractRepository = abstractRepository ?? throw new ArgumentNullException(nameof(abstractRepository));
        }

        //-- listar

        public List<TObject> Listar(TObject filtro) => _abstractRepository.ListarO(filtro).ToList();

        //-- consultar

        public TObject Consultar(TObject filtro) => _abstractRepository.ConsultarO(filtro);

        //-- incluir

        public void Incluir(TObject objeto) => _abstractRepository.Incluir(objeto);

        //-- alterar

        public void Alterar(TObject objeto) => _abstractRepository.Alterar(objeto);

        //-- salvar

        public void Salvar(TObject objeto) => _abstractRepository.Salvar(objeto);

        //-- excluir

        public void Excluir(TObject objeto) => _abstractRepository.Excluir(objeto);

        //-- sequencia

        public int Sequencia(TObject filtro) => _abstractRepository.Sequencia(filtro);
    }
}