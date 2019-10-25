namespace MORM.Apresentacao
{
    public class MinimizarCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            string.Empty.MinimizarApp();
        }
        #endregion
    }
}