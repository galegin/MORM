using MORM.Utilidade.Atributos;
using MORM.Utilidade.Tipagens;
using System;

namespace MORM.Repositorio.Interfaces
{
    public interface IComando
    {
        TipoDatabase TipoDatabase { get; }
        string GetValueStr(object value);
        string GetValueStr(object obj, string atributo);
        string GetWhereKey(object obj);
        string GetWhereAll(object obj);
        string GetWhereObj<TObject>(object obj, CampoTipo[] campoTipo);
        string GetSelect(Type type, string where = null, int qtde = -1, int pagina = 0);
        string GetSelect(object obj);
        string GetInsert(object obj);
        string GetUpdate(object obj);
        string GetDelete(object obj);
        string GetSequenciaGen(Type type);
        string GetSequenciaMax(Type type, string where);
    }
}