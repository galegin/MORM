using MORM.Apresentacao.Views;
using MORM.WSist.ViewsModel.Manutencao;

namespace MORM.WSist.Views.Manutencao
{
    public class AbstractTerminalViewManut : AbstractViewManut, IAbstractTerminalViewManut
    {
        public AbstractTerminalViewManut()
        {
            CreateCampos(new AbstractTerminalViewModel());
        }
    }
}