using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("ProdutoKit")]
    public class ProdutoKitModel : AbstractModel
    {
        #region variaveis
        private int _id_ProdutoKit;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Kit;
        private int _id_Produto;
        private string _cd_ProdutoKit;
        #endregion
        
        #region propriedades
        public int Id_ProdutoKit
        {
            get => _id_ProdutoKit;
            set => SetField(ref _id_ProdutoKit, value);
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
        public int Id_Kit
        {
            get => _id_Kit;
            set => SetField(ref _id_Kit, value);
        }
        public int Id_Produto
        {
            get => _id_Produto;
            set => SetField(ref _id_Produto, value);
        }
        public string Cd_ProdutoKit
        {
            get => _cd_ProdutoKit;
            set => SetField(ref _cd_ProdutoKit, value);
        }
        #endregion
    }
}