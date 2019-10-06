using MORM.CrossCutting;
using System;

namespace MORM.Servico
{
    public class AmbienteAppService : IAmbienteAppService
    {
        private const string _mensagemAmbienteNaoCadastrado = "Ambiente nao cadastrado";
        private const string _mensagemUsuarioNaoCadastrado = "Usuario nao cadastrado";
        private const string _mensagemSenhaNaoCadastrada = "Senha nao cadastrada";
        private readonly IAmbienteRepository _ambienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AmbienteAppService(IAmbienteRepository ambienteRepository,
            IUsuarioRepository usuarioRepository)
        {
            _ambienteRepository = ambienteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public object Validar(ValidarAmbienteInModel model)
        {
            model.Validate();

            var ambienteFiltro = new Ambiente { Codigo = model.Ambiente };
            var ambiente = _ambienteRepository.GetById(ambienteFiltro);
            if (string.IsNullOrWhiteSpace(ambiente?.Codigo))
                throw new Exception(_mensagemAmbienteNaoCadastrado);

            var usuarioFiltro = new Usuario { Nm_Login = model.Login };
            var usuario = _usuarioRepository.GetById(usuarioFiltro);
            if (string.IsNullOrWhiteSpace(usuario?.Nm_Usuario))
                throw new Exception(_mensagemUsuarioNaoCadastrado);

            var senhaHash = HashExtensions.GetHash(model.Login, model.Senha);
            var senhaMd5 = Md5Extensions.GetMd5(senhaHash);

            if (!Md5Extensions.IsValidMd5(senhaHash, senhaMd5))
                throw new Exception(_mensagemSenhaNaoCadastrada);

            // provisorio
            //var ambiente = new Ambiente(); 

            var token = new Token(ambiente, true).GetToken();

            return new ValidarAmbienteOutModel
            {
                Ambiente = null,
                Token = token,
            };
        }
    }
}