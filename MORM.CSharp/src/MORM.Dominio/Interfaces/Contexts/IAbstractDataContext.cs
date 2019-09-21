using System;
using System.Collections;

namespace MORM.Dominio.Interfaces
{
    public interface IAbstractDataContext : IDisposable
    {
        IConexao GetConexao();
        IComando GetComando();
        IDbSet<TObject> Set<TObject>();
        void SetAmbiente(IAmbiente ambiente);
        IList GetLista(Type type, object filtro = null, bool relacao = false, int qtde = -1, int pagina = 0);
        object GetObjeto(Type type, object filtro = null, bool relacao = true);
        void SetObjeto(object obj, bool relacao = true);
        void InsObjeto(object obj, bool relacao = true);
        void UpdObjeto(object obj, bool relacao = true);
        void RemObjeto(object obj, bool relacao = true);
        long IncObjeto<TObject>(object filtro = null);
    }
}