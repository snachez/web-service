//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xcolor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TelefonoCliente
    {
        public int ID { get; set; }
        public int idCliente { get; set; }
        public int idTipoTelefono { get; set; }
        public string telefono { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual TipoTelefono TipoTelefono { get; set; }
    }
}
