using System;
using System.Windows.Forms;
using MORM.Apresentacao.Properties;

namespace MORM.Apresentacao.Comps
{
    public class AbstractNotifyIcon
    {
        #region Variaveis
        private NotifyIcon _trayIcon;
        #endregion

        #region Propriedades
        public bool Ativo
        {
            get => _trayIcon.Visible;
            set => _trayIcon.Visible = value;
        }
        #endregion

        #region Construtores
        public AbstractNotifyIcon(EventHandler eventoRestaurar)
        {
            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Restaurar", eventoRestaurar),
                    new MenuItem("Finalizar", EventoFinalizar),
                }),
                Visible = false
            };
        }
        #endregion

        #region Metodos
        public void EventoFinalizar(object sender, EventArgs e)
        {
            if (MessageBox.Show("Finalizar ?", "Confirmação", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _trayIcon.Visible = false;

            Application.Exit();
        }
        #endregion
    }
}