using System;
using System.Collections.Generic;
using MORM.Dominio.Atributos;

namespace MORM.Repositorio.Tests
{
    [Tabela("TIPO")]
    public class TipoModel
    {
        public TipoModel()
        {
        }

        public TipoModel(int cd_Tipo, string ds_Tipo)
        {
            Cd_Tipo = cd_Tipo;
            Ds_Tipo = ds_Tipo ?? throw new ArgumentNullException(nameof(ds_Tipo));
        }

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
            var hashCode = 23932796;
            hashCode = hashCode * -1521134295 + Cd_Tipo.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ds_Tipo);
            return hashCode;
        }
    }
}