using System;
using System.Windows.Forms;
using MORM.Apresentacao.Properties;
using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public class AbstractNotifyIcon
    {
        #region Variaveis
        private NotifyIcon _trayIcon;
        private Action _actionFinalizar;
        #endregion

        #region Propriedades
        public bool Ativo
        {
            get => _trayIcon.Visible;
            set => _trayIcon.Visible = value;
        }
        #endregion

        #region Construtores
        public AbstractNotifyIcon(EventHandler onRestaurar = null, Action actionFinalizar = null)
        {
            _actionFinalizar = actionFinalizar != null ? actionFinalizar  : () => Application.Exit();

            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Restaurar", onRestaurar),
                    new MenuItem("Inicializar", OnInicializar),
                    new MenuItem("Finalizar", OnFinalizar),
                }),
                Visible = false
            };
        }
        #endregion

        #region Metodos
        public void OnInicializar(object sender, EventArgs e)
        {
            var isAtivo = InicializacaoApp.IsAtivo();
            var tituloConfirma = isAtivo ? "Desativar" : "Ativar";
            var tituloMensagem = isAtivo ? "desativada" : "ativada";

            if (MessageBox.Show($"{tituloConfirma} Inicialização ?", "Confirmação", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (isAtivo)
            {
                InicializacaoApp.Desativar();
                InicializacaoApp.IsInicializacao = true;
            }
            else
            {
                InicializacaoApp.Ativar();
                InicializacaoApp.IsInicializacao = false;
            }

            MessageBox.Show($"Inicialização {tituloMensagem} com sucesso");
        }
        public void OnFinalizar(object sender, EventArgs e)
        {
            if (MessageBox.Show("Finalizar ?", "Confirmação", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _trayIcon.Visible = false;

            _actionFinalizar?.Invoke();
        }
        #endregion
    }
}