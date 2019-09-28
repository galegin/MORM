using MORM.Apresentacao.Report.Interfaces;
using MORM.Apresentacao.Report.Types;
using System.Collections.Generic;

namespace MORM.Apresentacao.Report.Classes
{
    public class RelatorioParte : IRelatorioParte
    {
        public RelatorioParteTipo Tipo { get; set; }
        public IList<IRelatorioParte> Partes { get; set; }
        public IList<IRelatorioCampo> Campos { get; set; }
        public object Objeto { get; set; }
    }
}