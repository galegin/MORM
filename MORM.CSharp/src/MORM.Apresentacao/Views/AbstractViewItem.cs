using System;

namespace MORM.Apresentacao
{
    public class AbstractViewItem
    {
        public AbstractViewItem(string descricao, params object[] controls)
        {
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Controls = controls ?? throw new ArgumentNullException(nameof(controls));
        }

        public string Descricao { get; set; }
        public object[] Controls { get; set; }
    }
}