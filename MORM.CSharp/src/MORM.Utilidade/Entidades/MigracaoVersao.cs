using MORM.Utilidade.Atributos;

namespace MORM.Utilidade.Entidades
{
    //-- galeg - 31/03/2018 11:37:51
    [Tabela("MIGRACAO_VERSAO")]
    public class MigracaoVersao
    {
        public MigracaoVersao()
        {
        }

        public MigracaoVersao(string codigo, string versao)
        {
            Codigo = codigo;
            Versao = versao;
        }

        [Campo("CD_ENTIDADE", CampoTipo.Key, tamanho: 30)]
        public string Codigo { get; set; }
        [Campo("DS_VERSAO", CampoTipo.Req, tamanho: 30)]
        public string Versao { get; set; }
    }
}