//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Golestan.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bakhsh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bakhsh()
        {
            this.Shahids = new HashSet<Shahid>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> faal { get; set; }
        public Nullable<System.DateTime> dateupdate { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<int> IDShahrestan { get; set; }
    
        public virtual Shahrestan Shahrestan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shahid> Shahids { get; set; }
    }
}
