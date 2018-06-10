using MORM.Utilidade.Atributos;

namespace MORM.Utilidade.Entidades
{
    //-- galeg - 26/05/2018 17:19:26
    [Tabela("WEB_PERMISSAO")]
    public class Permissao
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