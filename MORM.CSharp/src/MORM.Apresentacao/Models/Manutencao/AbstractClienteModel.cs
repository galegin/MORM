using System;

namespace MORM.Apresentacao.Models.Manutencao
{
    public class AbstractClienteModel : AbstractModel, IAbstractClienteModel
    {
        public override string GetFiltroKey() => 
            $"{nameof(Codigo)} = {Codigo}";

        private int _codigo;
        public int Codigo 
        { 
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        
        private string _documento;
        public string Documento
        { 
            get => _documento;
            set => SetField(ref _documento, value);
        }
        
        private string _nome;
        public string Nome
        { 
            get => _nome;
            set => SetField(ref _nome, value);
        }
        
        private string _endereco;
        public string Endereco
        { 
            get => _endereco;
            set => SetField(ref _endereco, value);
        }
        
        private string _cidade;
        public string Cidade
        { 
            get => _cidade;
            set => SetField(ref _cidade, value);
        }
        
        private string _estado;
        public string Estado
        { 
            get => _estado;
            set => SetField(ref _estado, value);
        }
        
        private string _pais;
        public string Pais
        { 
            get => _pais;
            set => SetField(ref _pais, value);
        }
        
        private double _salario;
        public double Salario
        { 
            get => _salario;
            set => SetField(ref _salario, value);
        }
        
        private DateTime _nascto;
        public DateTime Nascto
        { 
            get => _nascto;
            set => SetField(ref _nascto, value);
        }
    }
}