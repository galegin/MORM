using System.Collections.Generic;

namespace MORM.Apresentacao
{
    public interface IMenuSistema
    {
        IList<IMenuOpcao> GetListaDeMenuOpcao();
    }
}