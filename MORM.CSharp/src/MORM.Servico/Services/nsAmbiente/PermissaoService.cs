using MORM.Repositorio.Extensions;
using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Dtos;

namespace MORM.Servico.Services
{
    public class PermissaoService : AbstractService<Permissao>, IPermissaoService
    {
        public PermissaoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        private Permissao GetPermissao(VerificarPermissaoDto.Envio dto)
        {
            return AbstractRepository.FirstOrDefault(f =>
                f.CodigoEmpresa == dto.CodigoEmpresa &&
                f.CodigoUsuario == dto.CodigoUsuario &&
                f.CodigoServico == dto.CodigoServico &&
                f.CodigoMetodo  == dto.CodigoMetodo);
        }

        public bool VerificarPermissao(VerificarPermissaoDto.Envio dto)
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