using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Commands.Tela
{
    public class MinimizarCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            "".MinimizarApp();
        }
        #endregion
    }
}