//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inmbiliariagestion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALQUIILER
    {
        public int codigoDpto { get; set; }
        public string Domicilio { get; set; }
        public Nullable<double> Tarifa { get; set; }
        public Nullable<double> Aumento { get; set; }
        public string Dni { get; set; }
        public bool Estado { get; set; }
        public virtual Inquilino Inquilino { get; set; }
    }
}
