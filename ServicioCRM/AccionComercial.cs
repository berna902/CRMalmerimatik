//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioCRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccionComercial
    {
        public int ID { get; set; }
        public int Usuario { get; set; }
        public int IDEmpresa { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Comentarios { get; set; }
        public int IDAccion { get; set; }
        public int IDEstado { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual TipoAccion TipoAccion { get; set; }
        public virtual User User { get; set; }
    }
}
