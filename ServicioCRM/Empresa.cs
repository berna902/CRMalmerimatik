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
    
    public partial class Empresa
    {
        public Empresa()
        {
            this.AccionComercial = new HashSet<AccionComercial>();
            this.Contacto = new HashSet<Contacto>();
            this.TelefonoEmpresa = new HashSet<TelefonoEmpresa>();
            this.Direccion = new HashSet<Direccion>();
        }
    
        public int ID { get; set; }
        public string CIF { get; set; }
        public string RazonSocial { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public int TipoEmpresa { get; set; }
    
        public virtual ICollection<AccionComercial> AccionComercial { get; set; }
        public virtual ICollection<Contacto> Contacto { get; set; }
        public virtual TipoEmpresa TipoEmpresa1 { get; set; }
        public virtual ICollection<TelefonoEmpresa> TelefonoEmpresa { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
    }
}
