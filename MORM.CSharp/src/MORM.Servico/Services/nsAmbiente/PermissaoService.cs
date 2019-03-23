using MORM.Repositorio.Extensions;
using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class PermissaoService : AbstractService<Permissao>, IPermissaoService
    {
        public PermissaoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public PermissaoService(IAmbiente ambiente) : base(ambiente)
        {
        }

        private Permissao GetPermissao(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo)
        {
            return AbstractRepository.FirstOrDefault(f =>
                f.CodigoEmpresa == codigoEmpresa &&
                f.CodigoUsuario == codigoUsuario &&
                f.CodigoServico == codigoServico &&
                f.CodigoMetodo  == codigoMetodo);
        }

        public bool VerificarPermissao(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo)
        {
            var permissao = GetPermissao(codigoEmpresa, codigoUsuario, codigoServico, codigoMetodo);

            if (permissao.CodigoEmpresa <= 0)
                permissao = GetPermissao(codigoEmpresa, codigoUsuario, codigoServico, "TODOS");

            if (permissao.CodigoEmpresa <= 0)
                permissao = GetPermissao(codigoEmpresa, codigoUsuario, "TODOS", "TODOS");

            if (permissao.CodigoEmpresa <= 0)
                permissao = GetPermissao(codigoEmpresa, 999999, "TODOS", "TODOS");

            if (permissao.CodigoEmpresa <= 0)
                permissao = GetPermissao(9999, 999999, "TODOS", "TODOS");

            return permissao.CodigoEmpresa > 0;
        }
    }
}