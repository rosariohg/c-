//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab11_A
{
    using System;
    using System.Collections.Generic;
    
    public partial class Individual
    {
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
        public string Demographics { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
