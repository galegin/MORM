using MORM.Utilidade.Interfaces;
using System.Collections;

namespace MORM.Repositorio.Interfaces
{
    //-- galeg - 28/04/2018 15:24:57
    public interface IAbstractDataContext
    {
        IAmbiente Ambiente { get; }
        IConexao Conexao { get; }
        IComando Comando { get; }
        IMigracao Migracao { get; }
        void SetAmbiente(IAmbiente ambiente);
        void GetLista(IList lista, string where = null, bool relacao = false, int qtde = -1, int pagina = 0);
        void GetObjeto(object obj, string where = null, bool relacao = true);
        void SetObjeto(object obj, bool relacao = true);
        void InsObjeto(object obj, bool relacao = true);
        void UpdObjeto(object obj, bool relacao = true);
        void RemObjeto(object obj, bool relacao = true);
    }
}