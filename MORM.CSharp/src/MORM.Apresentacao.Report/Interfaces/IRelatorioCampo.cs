using MORM.Apresentacao.Report.Types;

namespace MORM.Apresentacao.Report.Interfaces
{
    public interface IRelatorioCampo
    {
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Tamanho { get; set; }
        int Precisao { get; set; }
        RelatorioAlinhamento Alinhamento { get; set; }
    }
}