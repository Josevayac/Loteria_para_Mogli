//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sorteo
    {
        public Sorteo()
        {
            this.Premio = new HashSet<Premio>();
        }
    
        public int id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Titulo { get; set; }
    
        public virtual ICollection<Premio> Premio { get; set; }
    }
}