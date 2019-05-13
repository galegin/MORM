using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Login.Commands
{
    public class FecharLogin : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.MainLogin.FecharTela();
        }
    }
}