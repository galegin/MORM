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
    
    public partial class EstadoIBGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoIBGE()
        {
            this.MunIBGE = new HashSet<MunIBGE>();
        }
    
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MunIBGE> MunIBGE { get; set; }
    }
}
