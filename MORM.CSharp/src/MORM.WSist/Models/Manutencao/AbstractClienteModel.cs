using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.WSist.Models.Manutencao
{
    [SVC("Cliente")]
    public class AbstractClienteModel : AbstractModel
    {
        #region variaveis
        private int _codigo;
        private string _documento;
        private string _nome;
        private string _endereco;
        private string _cidade;
        private string _estado;
        private string _pais;
        private double _salario;
        private DateTime _nascto;
        #endregion

        #region propriedades
        public int Codigo 
        { 
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        
        [Tamanho(20)]
        public string Documento
        { 
            get => _documento;
            set => SetField(ref _documento, value);
        }
        
        public string Nome
        { 
            get => _nome;
            set => SetField(ref _nome, value);
        }
        
        public string Endereco
        { 
            get => _endereco;
            set => SetField(ref _endereco, value);
        }

        [Tamanho(30)]
        public string Cidade
        { 
            get => _cidade;
            set => SetField(ref _cidade, value);
        }

        [Tamanho(20)]
        public string Estado
        { 
            get => _estado;
            set => SetField(ref _estado, value);
        }

        [Tamanho(20)]
        public string Pais
        { 
            get => _pais;
            set => SetField(ref _pais, value);
        }
        
        public double Salario
        { 
            get => _salario;
            set => SetField(ref _salario, value);
        }
        
        public DateTime Nascto
        { 
            get => _nascto;
            set => SetField(ref _nascto, value);
        }
        #endregion
    }
}