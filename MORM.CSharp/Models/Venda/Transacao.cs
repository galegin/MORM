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
    using System.Collections.Generic;
    
    public partial class Transacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transacao()
        {
            this.TransacaoItem = new HashSet<TransacaoItem>();
        }
    
        public int Sequencia { get; set; }
        public System.DateTime Data { get; set; }
        public TipoDocumentoFiscal TipoDocumentoFiscal { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public TipoModalidade TipoModalidade { get; set; }
        public string SerieFiscal { get; set; }
        public int NumeroNota { get; set; }
        public double ValorBruto { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorAcrescimo { get; set; }
        public double ValorLiquido { get; set; }
        public System.DateTime DataCancelamento { get; set; }
    
        public virtual Pagamento Pagamento { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransacaoItem> TransacaoItem { get; set; }
    }
}
