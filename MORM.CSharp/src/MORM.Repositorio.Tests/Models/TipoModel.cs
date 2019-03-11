using System;
using MORM.Utilidade.Atributos;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 15/04/2018 11:21:37
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
    }
}