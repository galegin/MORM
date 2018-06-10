using MORM.Utilidade.Entidades;

namespace MORM.Repositorio.Services.nsAmbiente
{
    //-- galeg - 26/05/2018 17:38:11
    public interface IPermissaoService : IAbstractService<Permissao>
    {
        bool VerificarPermissao(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo);
    }
}