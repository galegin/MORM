using MORM.Apresentacao.Report.Interfaces;
using MORM.Apresentacao.Report.Types;
using System;

namespace MORM.Apresentacao.Report.Classes
{
    public class RelatorioCampo : IRelatorioCampo
    {
        public RelatorioCampo(string codigo, 
            string descricao = null, 
            int tamanho = 0, 
            int precisao = 0, 
            RelatorioAlinhamento alinhamento = RelatorioAlinhamento.Esquerda)
        {
            Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
            Descricao = descricao;
            Tamanho = tamanho;
            Precisao = precisao;
            Alinhamento = alinhamento;
        }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Precisao { get; set; }
        public RelatorioAlinhamento Alinhamento { get; set; }
    }
}