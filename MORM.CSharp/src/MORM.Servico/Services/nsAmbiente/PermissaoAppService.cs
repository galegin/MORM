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

        private Permissao GetPermissao(VerificarPermissaoInModel dto)
        {
            return AbstractService.AbstractRepository.FirstOrDefault(f =>
                f.CodigoEmpresa == dto.CodigoEmpresa &&
                f.CodigoUsuario == dto.CodigoUsuario &&
                f.CodigoServico == dto.CodigoServico &&
                f.CodigoMetodo  == dto.CodigoMetodo);
        }

        public bool VerificarPermissao(VerificarPermissaoInModel dto)
        {
            var permissao = GetPermissao(dto);

            if (permissao.CodigoEmpresa <= 0)
            {
                dto.CodigoMetodo = "TODOS";
                permissao = GetPermissao(dto);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                dto.CodigoServico = "TODOS";
                dto.CodigoMetodo = "TODOS";
                permissao = GetPermissao(dto);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                dto.CodigoUsuario = 999999;
                dto.CodigoServico = "TODOS";
                dto.CodigoMetodo = "TODOS";
                permissao = GetPermissao(dto);
            }

            if (permissao.CodigoEmpresa <= 0)
            {
                dto.CodigoEmpresa = 9999;
                dto.CodigoUsuario = 999999;
                dto.CodigoServico = "TODOS";
                dto.CodigoMetodo = "TODOS";
                permissao = GetPermissao(dto);
            }

            return permissao.CodigoEmpresa > 0;
        }
    }
}