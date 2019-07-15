namespace MORM.Apresentacao.Report.Comuns
{
    public enum CampoTipo
    {
        Boolean,
        Data,
        Numero,
        Valor,
        Texto,
    }

    public enum CampoAlinhamento
    {
        Direita,
        Centro,
        Esquerda,
        Justificado
    }

    public interface ICampoLista
    {
        string Codigo { get; }
        string Descricao { get; }
        int Tamanho { get; }
        int Precisao { get; }
        CampoTipo Tipo { get; }
        CampoAlinhamento Alinhamento { get; }
    }
}