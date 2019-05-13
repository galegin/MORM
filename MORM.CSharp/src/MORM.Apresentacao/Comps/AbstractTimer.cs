using System;
using System.Threading;

namespace MORM.Apresentacao.Comps
{
    public delegate void OnTimerExecute(object sender);

    public class AbstractTimer
    {
        #region constantes
        private const int TEMPO_TIMER = 60 * 1000;
        #endregion

        #region variaveis
        private Timer _timer;
        private event OnTimerExecute _onTimerExecute;
        #endregion

        #region construtores
        public AbstractTimer(OnTimerExecute onTimerExecute)
        {
            SetarTimer(onTimerExecute ?? throw new ArgumentNullException(nameof(onTimerExecute)));
        }
        #endregion

        #region metodos
        private void OnCallBack(object sender)
        {
            Parar();
            _onTimerExecute?.Invoke(sender);
            Iniciar();
        }
        private void SetarTimer(OnTimerExecute onTimerExecute)
        {
            _onTimerExecute = onTimerExecute;
            if (_timer == null)
                _timer = new Timer(OnCallBack, null, TEMPO_TIMER, Timeout.Infinite);
            _onTimerExecute?.Invoke(null);
        }
        public void Iniciar()
        {
            if (_timer != null)
                _timer.Change(0, TEMPO_TIMER); //restarts the timer
        }
        public void Parar()
        {
            if (_timer != null)
                _timer.Change(Timeout.Infinite, Timeout.Infinite); //stops the timer
        }
        #endregion
    }
}