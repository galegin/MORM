using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("MigracaoEnt")]
    public class MigracaoEntModel : AbstractModel
    {
        #region variaveis
        private string _codigo;
        private string _versao;
        #endregion
        
        #region propriedades
        public string Codigo
        {
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        public string Versao
        {
            get => _versao;
            set => SetField(ref _versao, value);
        }
        #endregion
    }
}