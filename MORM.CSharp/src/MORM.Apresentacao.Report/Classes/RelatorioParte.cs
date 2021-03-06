﻿using System.Collections.Generic;

namespace MORM.Apresentacao.Report
{
    public class RelatorioParte : IRelatorioParte
    {
        public RelatorioParteTipo Tipo { get; set; }
        public IList<IRelatorioParte> Partes { get; set; }
        public IList<IRelatorioCampo> Campos { get; set; }
        public object Objeto { get; set; }
    }
}