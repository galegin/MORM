﻿namespace MORM.Apresentacao
{
    public class AbstractViewModelRelat<TModel> : AbstractViewModel<TModel>, IAbstractViewModelRelat
        where TModel : class
    {
        #region construtores
        public AbstractViewModelRelat() : base()
        {
        }
        #endregion
    }
}