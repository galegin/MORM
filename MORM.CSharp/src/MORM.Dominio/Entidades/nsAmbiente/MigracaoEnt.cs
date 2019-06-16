using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;

namespace MORM.Dominio.Entidades
{
    [Tabela("_MIGRACAO")]
    public class MigracaoEnt : IMigracaoEnt
    {
        public MigracaoEnt()
        {
        }

        public MigracaoEnt(string codigo, string versao)
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