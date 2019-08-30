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
        public AbstractNotifyIcon(EventHandler onRestaurar = null)
        {
            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Restaurar", onRestaurar),
                    new MenuItem("Finalizar", OnFinalizar),
                }),
                Visible = false
            };
        }
        #endregion

        #region Metodos
        public void OnFinalizar(object sender, EventArgs e)
        {
            if (MessageBox.Show("Finalizar ?", "Confirmação", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _trayIcon.Visible = false;

            Application.Exit();
        }
        #endregion
    }
}