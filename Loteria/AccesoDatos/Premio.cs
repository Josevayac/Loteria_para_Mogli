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
    
    public partial class Premio
    {
        public int id { get; set; }
        public int numero { get; set; }
        public decimal monto { get; set; }
        public int importancia { get; set; }
        public int sorteo { get; set; }
    
        public virtual Sorteo Sorteo1 { get; set; }
    }
}