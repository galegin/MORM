using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("TipoVariacaoMotivo")]
    public class TipoVariacaoMotivoModel : AbstractModel
    {
        #region variaveis
        private int _id_TipoVariacaoMotivo;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_TipoVariacaoMotivo;
        private string _ds_TipoVariacaoMotivo;
        #endregion
        
        #region propriedades
        public int Id_TipoVariacaoMotivo
        {
            get => _id_TipoVariacaoMotivo;
            set => SetField(ref _id_TipoVariacaoMotivo, value);
        }
        public string U_Version
        {
            get => _u_Version;
            set => SetField(ref _u_Version, value);
        }
        public int Cd_Operador
        {
            get => _cd_Operador;
            set => SetField(ref _cd_Operador, value);
        }
        public DateTime Dt_Cadastro
        {
            get => _dt_Cadastro;
            set => SetField(ref _dt_Cadastro, value);
        }
        public string Cd_TipoVariacaoMotivo
        {
            get => _cd_TipoVariacaoMotivo;
            set => SetField(ref _cd_TipoVariacaoMotivo, value);
        }
        public string Ds_TipoVariacaoMotivo
        {
            get => _ds_TipoVariacaoMotivo;
            set => SetField(ref _ds_TipoVariacaoMotivo, value);
        }
        #endregion
    }
}