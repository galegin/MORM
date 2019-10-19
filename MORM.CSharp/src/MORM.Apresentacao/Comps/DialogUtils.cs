using MORM.CrossCutting;
using System.Windows;

namespace MORM.Apresentacao
{
    public static class DialogUtils
    {
        #region metodos
        private static string GetFileDialog(string initialDirectory = null, string fileName = null,
            string defaultExt = null, string filter = null, bool isOpenFile = true)
        {
            Microsoft.Win32.FileDialog dlg = isOpenFile 
                ? new Microsoft.Win32.OpenFileDialog() as Microsoft.Win32.FileDialog
                : new Microsoft.Win32.SaveFileDialog() as Microsoft.Win32.FileDialog
                ;

            dlg.InitialDirectory = initialDirectory ?? CaminhoPadrao.GetPathSubPasta();
            dlg.FileName = fileName ?? "Arquivo"; // Default file name
            dlg.DefaultExt = defaultExt ?? ".txt"; // Default file extension
            dlg.Filter = filter ?? "Arquivo TXT (.txt)|*.txt"; // Filter files by extension

            return dlg.ShowDialog() ?? false ? dlg.FileName : null;
        }

        public static string GetOpenFile(string initialDirectory = null, string fileName = null,
            string defaultExt = null, string filter = null)
        {
            return GetFileDialog(initialDirectory: initialDirectory, fileName: fileName,
                defaultExt: defaultExt, filter: filter,
                isOpenFile: true);
        }

        public static string GetSaveFile(string initialDirectory = null, string fileName = null, 
            string defaultExt = null, string filter = null)
        {
            return GetFileDialog(initialDirectory: initialDirectory, fileName: fileName,
                defaultExt: defaultExt, filter: filter,
                isOpenFile: false);
        }

        public static bool GetConfirmacao(this string mensagem, string caption = null, 
            MessageBoxButton? buttons = null, MessageBoxImage? images = null)
        {
            return MessageBox.Show(mensagem, caption ?? "Confirmação", 
                buttons ?? MessageBoxButton.YesNo, images ?? MessageBoxImage.Question) == 
                MessageBoxResult.Yes;
        }

        public static void GetMensagem(this string mensagem, string caption = null, 
            MessageBoxButton? button = null, MessageBoxImage? images = null)
        {
            MessageBox.Show(mensagem, caption ?? "Mensagem", 
                button ?? MessageBoxButton.OK, images ?? MessageBoxImage.Information);
        }
        #endregion
    }
}