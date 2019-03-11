using System;

namespace MORM.Apresentacao.Models.Manutencao
{
    public interface IAbstractClienteModel : IAbstractModel
    {
        int Codigo { get; }
        string Documento { get; }
        string Nome { get; }
        string Endereco { get; }
        string Cidade { get; }
        string Estado { get; }
        string Pais { get; }
        double Salario { get; }
        DateTime Nascto { get; }
    }
}