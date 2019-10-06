using System;
using System.Collections.Generic;
using MORM.CrossCutting;

namespace MORM.Repositorio.Tests
{
    [Tabela("TIPO")]
    public class TipoModel
    {
        [Campo("CD_TIPO", CampoTipo.Key)]
        public int Cd_Tipo { get; set; }
        [Campo("DS_TIPO", CampoTipo.Req)]
        public string Ds_Tipo { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as TipoModel)?.Cd_Tipo == Cd_Tipo;
        }

        public override int GetHashCode()
        {
            return 1857009019 + Cd_Tipo.GetHashCode();
        }
    }
}