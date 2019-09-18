using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Models;
using MORM.Servico.Interfaces;
using MORM.CrossCutting;
using System;
using System.Linq;

namespace MORM.Servico.Services
{
    public class AmbienteAppService : IAmbienteAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AmbienteAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public object Validar(ValidarAmbienteInModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Login))
                throw new Exception("Usuario deve ser informado");
            if (string.IsNullOrWhiteSpace(model.Senha))
                throw new Exception("Senha deve ser informada");

            var usuario = _usuarioRepository.GetAll()?.FirstOrDefault(x => x.Nm_Login == model.Login);
            if (string.IsNullOrWhiteSpace(usuario?.Nm_Usuario))
                throw new Exception("Usuario nao cadastrado");

            var senhaHash = HashExtensions.GetHash(model.Login, model.Senha);
            var senhaMd5 = Md5Extensions.GetMd5(senhaHash);

            if (!Md5Extensions.IsValidMd5(senhaHash, senhaMd5))
                throw new Exception("Senha nao cadastrada");

            var ambiente = new Ambiente(); // provisorio

            var token = new Token(ambiente, true).GetToken();

            return new ValidarAmbienteOutModel
            {
                Ambiente = null,
                Token = token,
            };
        }
    }
}