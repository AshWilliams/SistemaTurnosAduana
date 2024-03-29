//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaTurnos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.CambioTurno = new HashSet<CambioTurno>();
            this.CambioTurno1 = new HashSet<CambioTurno>();
            this.Contrato = new HashSet<Contrato>();
            this.Permisos = new HashSet<Permisos>();
            this.TurnoUsuario = new HashSet<TurnoUsuario>();
        }

        [Display(Name = "Id Usuario")]
        public int IdUsuario { get; set; }
        [Display(Name = "Email")]
        public string VEmail { get; set; }
        [Display(Name = "Contraseņa")]
        public string VPass { get; set; }
        [Display(Name = "RUT")]
        public string VRut { get; set; }
        [Display(Name = "Nombre")]
        public string VNombre { get; set; }
        [Display(Name = "Apellido")]
        public string VApellido { get; set; }
        
        [Display(Name = "Tipo Usuario")]
        public Nullable<int> IdTipoUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CambioTurno> CambioTurno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CambioTurno> CambioTurno1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos> Permisos { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurnoUsuario> TurnoUsuario { get; set; }
    }
}
