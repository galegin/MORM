using MORM.Utilidade.Atributos;
using MORM.Utilidade.Tipagens;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Interfaces
{
    public interface IComando
    {
        IComando ComTipoDatabase(TipoDatabase tipoDatabase);
        IComando ComTipoObjeto(Type tipoObjeto);
        IComando ComObjeto(object objeto);
        IComando ComParametros(IList<IParametro> parametros);
        IComando ComTipoCampo(CampoTipo[] campoTipos);
        IComando ComWhere(string where);
        IComando ComQtde(int qtde = -1);
        IComando ComPagina(int pagina = 0);
        string GetWhereKey();
        string GetWhereAll();
        string GetWhereObj();
        string GetSelect();
        string GetSelectKey();
        string GetInsert();
        string GetUpdate();
        string GetDelete();
        string GetSequenciaGen();
        string GetSequenciaMax();
    }
}