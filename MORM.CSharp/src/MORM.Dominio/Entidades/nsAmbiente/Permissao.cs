using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;

namespace MORM.Dominio.Entidades
{
    [Tabela("WEB_PERMISSAO")]
    public class Permissao : IPermissao
    {
        [Campo("CD_EMPRESA", CampoTipo.Key)]
        public int CodigoEmpresa { get; set; }
        [Campo("CD_USUARIO", CampoTipo.Key)]
        public int CodigoUsuario { get; set; }
        [Campo("CD_SERVICO", CampoTipo.Key)]
        public string CodigoServico { get; set; }
        [Campo("CD_METODO", CampoTipo.Key)]
        public string CodigoMetodo { get; set; }
    }
}