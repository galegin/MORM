﻿namespace MORM.Apresentacao
{
    public class RestaurarCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            string.Empty.RestaurarApp();
        }
        #endregion
    }
}