using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Dtos;
using MORM.Servico.Interfaces;
using MORM.Utils.Extensions;
using System;
using System.Linq;

namespace MORM.Servico.Services
{
    public class AmbienteService : AbstractService<Ambiente>, IAmbienteService
    {
        private readonly IUsuarioService _usuarioService;

        public AmbienteService(IAbstractUnityOfWork unityOfWork, IUsuarioService usuarioService) : base(unityOfWork)
        {
            _usuarioService = usuarioService;
        }

        public ValidarAmbienteDto.Retorno Validar(ValidarAmbienteDto.Envio dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Login))
                throw new Exception("Usuario deve ser informado");
            if (string.IsNullOrWhiteSpace(dto.Senha))
                throw new Exception("Senha deve ser informada");

            var usuarioFiltro = new Usuario { Nm_Login = dto.Login };
            var usuario = _usuarioService.Listar(usuarioFiltro)?.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(usuario?.Nm_Usuario))
                throw new Exception("Usuario nao cadastrado");

            var senhaHash = HashExtensions.GetHash(dto.Login, dto.Senha);
            var senhaMd5 = Md5Extensions.GetMd5(senhaHash);

            if (!Md5Extensions.IsValidMd5(senhaHash, senhaMd5))
                throw new Exception("Senha nao cadastrada");

            return new ValidarAmbienteDto.Retorno
            {
                Ambiente = new Ambiente(),
            };
        }
    }
}