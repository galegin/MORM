using System;

namespace MORM.CrossCutting
{
    public class ErroOutModel
    {
        #region propriedades
        public string dsErro { get; private set; }
        #endregion

        #region construtores
        public ErroOutModel(string dsErro)
        {
            this.dsErro = dsErro ?? throw new ArgumentNullException(nameof(dsErro));
        }
        #endregion
    }
}