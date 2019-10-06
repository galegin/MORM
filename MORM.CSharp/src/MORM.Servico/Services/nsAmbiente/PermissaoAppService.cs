using MORM.CrossCutting;
using System.Linq;

namespace MORM.Servico
{
    public class PermissaoAppService : IPermissaoAppService
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private const string TODOS = nameof(TODOS);

        public PermissaoAppService(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        private Permissao GetPermissao(VerificarPermissaoInModel model)
        {
            return _permissaoRepository.GetAll().FirstOrDefault(f =>
                f.CodigoEmpresa == model.CodigoEmpresa &&
                f.CodigoUsuario == model.CodigoUsuario &&
                f.CodigoServico == model.CodigoServico &&
                f.CodigoMetodo  == model.CodigoMetodo);
        }

        public bool VerificarPermissao(VerificarPermissaoInModel model)
        {
            var permissao = GetPermissao(model);

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoMetodo = TODOS;
                permissao = GetPermissao(model);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoServico = TODOS;
                permissao = GetPermissao(model);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoUsuario = 999999;
                permissao = GetPermissao(model);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoEmpresa = 9999;
                permissao = GetPermissao(model);
            }

            return permissao.CodigoEmpresa > 0;
        }
    }
}