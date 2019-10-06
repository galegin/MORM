namespace MORM.CrossCutting
{
    public interface IInformacaoSistema
    {
        IAmbiente Ambiente { get; }
        IEmpresa Empresa { get; }
        IUsuario Usuario { get; }
        ITerminal Terminal { get; }
    }
}