//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoVenda.Dominio.Entities
{
    using System;
    
    public partial class Endereco
    {
        public Endereco()
        {
            this.Municipio = new Municipio();
            this.Estado = new Estado();
            this.Pais = new Pais();
        }
    
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
    
        public Municipio Municipio { get; set; }
        public Estado Estado { get; set; }
        public Pais Pais { get; set; }
    }
}
