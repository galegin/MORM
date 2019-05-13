using System;

namespace MORM.Report.Comuns
{
    public class CampoLista : ICampoLista
    {
        public CampoLista(string codigo, string descricao, 
            int tamanho = 0, 
            int precisao = 0,
            CampoTipo? tipo = null,
            CampoAlinhamento? alinhamento = null)
        {
            Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Tamanho = tamanho;
            Precisao = precisao;
            Tipo = tipo ?? CampoTipo.Texto;
            Alinhamento = alinhamento ?? CampoAlinhamento.Esquerda;
        }

        public string Codigo { get; }
        public string Descricao { get; }
        public int Tamanho { get; }
        public int Precisao { get; }
        public CampoTipo Tipo { get; }
        public CampoAlinhamento Alinhamento { get; }

        public override bool Equals(object obj)
        {
            return (obj as CampoLista)?.Codigo?.Equals(Codigo) ?? false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}