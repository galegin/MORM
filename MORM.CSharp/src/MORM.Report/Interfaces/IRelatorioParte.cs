using MORM.Report.Tipagens;
using System.Collections.Generic;

namespace MORM.Report.Interfaces
{
    public interface IRelatorioParte
    {
        RelatorioParteTipo Tipo { get; set; }
        IList<IRelatorioParte> Partes { get; set; }
        IList<IRelatorioCampo> Campos { get; set; }
        object Objeto { get; set; }
    }
}