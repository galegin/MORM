using System.Collections.Generic;

namespace MORM.Apresentacao.Menus
{
    public interface IMenuSistema
    {
        IList<IMenuOpcao> GetListaDeMenuOpcao();
    }
}