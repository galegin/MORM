namespace MORM.Dtos.nsAmbiente
{
    public abstract class VerificarPermissaoDto
    {
        public class Envio
        {
            public int CodigoEmpresa { get; set; }
            public int CodigoUsuario { get; set; }
            public string CodigoServico { get; set; }
            public string CodigoMetodo { get; set; }
        }
    }
}