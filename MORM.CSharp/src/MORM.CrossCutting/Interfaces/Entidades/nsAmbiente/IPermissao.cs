namespace MORM.CrossCutting
{
    public interface IPermissao
    {
        int CodigoEmpresa { get; set; }
        int CodigoUsuario { get; set; }
        string CodigoServico { get; set; }
        string CodigoMetodo { get; set; }
    }
}