using MORM.Dominio.Entidades;

namespace MORM.Servico.Interfaces.nsAmbiente
{
    public interface IPermissaoService : IAbstractService<Permissao>
    {
        bool VerificarPermissao(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo);
    }
}