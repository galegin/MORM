using System;
using System.Timers;

namespace MORM.Apresentacao.Comps
{
    public delegate void OnTimerExecute(object sender);

    public class AbstractTimer
    {
        #region variaveis
        private Timer _timer;
        private event OnTimerExecute _onTimerExecute;
        private object _lock = new object();
        private int _tempo;
        #endregion

        #region propriedades
        public const int TEMPO_SECOND = 1000;
        public const int TEMPO_TIMER = 60 * TEMPO_SECOND;
        public bool Ativo
        {
            get => _timer.Enabled;
            set => _timer.Enabled = value;
        }
        #endregion

        #region construtores
        public AbstractTimer(OnTimerExecute onTimerExecute, int? tempo = null)
        {
            _tempo = tempo ?? TEMPO_TIMER;
            SetarTimer(onTimerExecute ?? throw new ArgumentNullException(nameof(onTimerExecute)));
        }
        #endregion

        #region metodos
        public void Iniciar() => _timer.Start();
        public void Parar() => _timer.Stop();
        private void SetarTimer(OnTimerExecute onTimerExecute)
        {
            _onTimerExecute = onTimerExecute;

            if (_timer == null)
            {
                _timer = new Timer(_tempo);
                _timer.Elapsed += OnTimedEvent;
                _timer.AutoReset = true;
                _timer.Enabled = true;
            }
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            lock (_lock)
            {
                Parar();
                _onTimerExecute?.Invoke(sender);
                Iniciar();
            }
        }
        #endregion
    }
}