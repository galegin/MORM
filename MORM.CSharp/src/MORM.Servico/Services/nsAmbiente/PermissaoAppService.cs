using MORM.Dominio.Entidades;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;
using MORM.Servico.Models;

namespace MORM.Servico.Services
{
    public class PermissaoAppService : AbstractAppService<Permissao>, IPermissaoAppService
    {
        public PermissaoAppService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        private Permissao GetPermissao(VerificarPermissaoInModel model)
        {
            return AbstractService.AbstractRepository.FirstOrDefault(f =>
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
                model.CodigoMetodo = "TODOS";
                permissao = GetPermissao(model);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoServico = "TODOS";
                model.CodigoMetodo = "TODOS";
                permissao = GetPermissao(model);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoUsuario = 999999;
                model.CodigoServico = "TODOS";
                model.CodigoMetodo = "TODOS";
                permissao = GetPermissao(model);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                model.CodigoEmpresa = 9999;
                model.CodigoUsuario = 999999;
                model.CodigoServico = "TODOS";
                model.CodigoMetodo = "TODOS";
                permissao = GetPermissao(model);
            }

            return permissao.CodigoEmpresa > 0;
        }
    }
}