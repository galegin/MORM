namespace MORM.Apresentacao
{
    public class FecharLogin : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.MainLogin.FecharTela();
        }
    }
}