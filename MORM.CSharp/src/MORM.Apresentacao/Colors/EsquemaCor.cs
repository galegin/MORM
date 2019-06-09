using System;

namespace MORM.Apresentacao.Colors
{
    public class EsquemaCor
    {
        public EsquemaCor() { }

        public EsquemaCor(EsquemaTipo tipo, string corFonte, string corFundo, bool isItalico, bool isNegrito, bool isSublinhado, double tamFonte)
        {
            Tipo = tipo;
            CorFonte = corFonte ?? throw new ArgumentNullException(nameof(corFonte));
            CorFundo = corFundo ?? throw new ArgumentNullException(nameof(corFundo));
            IsItalico = isItalico;
            IsNegrito = isNegrito;
            IsSublinhado = isSublinhado;
            TamFonte = tamFonte;
        }

        public EsquemaTipo Tipo { get; set; }
        public string CorFonte { get; set; }
        public string CorFundo { get; set; }
        public bool IsItalico { get; set; }
        public bool IsNegrito { get; set; }
        public bool IsSublinhado { get; set; }
        public double TamFonte { get; set; }
    }
}