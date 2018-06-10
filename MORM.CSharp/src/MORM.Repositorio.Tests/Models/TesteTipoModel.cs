using MORM.Utilidade.Atributos;

namespace MORM.Repositorio.Tests.Models
{
    //-- galeg - 15/04/2018 11:21:37
    [Tabela("TIPO")]
    public class TesteTipoModel
    {
        [Campo("CD_TIPO", CampoTipo.Key)]
        public int Codigo { get; set; }
        [Campo("DS_TIPO", CampoTipo.Req)]
        public string Descricao { get; set; }
    }
}