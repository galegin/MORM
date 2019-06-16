using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("ProdutoBarra")]
    public class ProdutoBarraModel : AbstractModel
    {
        #region variaveis
        private int _id_ProdutoBarra;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Produto;
        private string _cd_ProdutoBarra;
        private double _qt_Embalagem;
        private bool _in_Padrao;
        #endregion
        
        #region propriedades
        public int Id_ProdutoBarra
        {
            get => _id_ProdutoBarra;
            set => SetField(ref _id_ProdutoBarra, value);
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
        public int Id_Produto
        {
            get => _id_Produto;
            set => SetField(ref _id_Produto, value);
        }
        public string Cd_ProdutoBarra
        {
            get => _cd_ProdutoBarra;
            set => SetField(ref _cd_ProdutoBarra, value);
        }
        public double Qt_Embalagem
        {
            get => _qt_Embalagem;
            set => SetField(ref _qt_Embalagem, value);
        }
        public bool In_Padrao
        {
            get => _in_Padrao;
            set => SetField(ref _in_Padrao, value);
        }
        #endregion
    }
}