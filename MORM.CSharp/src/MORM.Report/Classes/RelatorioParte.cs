using MORM.Report.Interfaces;
using MORM.Report.Tipagens;
using System.Collections.Generic;

namespace MORM.Report.Classes
{
    public class RelatorioParte : IRelatorioParte
    {
        public RelatorioParteTipo Tipo { get; set; }
        public IList<IRelatorioParte> Partes { get; set; }
        public IList<IRelatorioCampo> Campos { get; set; }
        public object Objeto { get; set; }
    }
}