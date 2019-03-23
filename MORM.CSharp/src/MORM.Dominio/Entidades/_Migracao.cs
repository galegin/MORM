using MORM.Dominio.Atributos;

namespace MORM.Dominio.Entidades
{
    [Tabela("_MIGRACAO")]
    public class Migracao
    {
        public Migracao()
        {
        }

        public Migracao(string codigo, string versao)
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