//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace stomatology.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Zapisi = new HashSet<Zapisi>();
            this.Zapisi1 = new HashSet<Zapisi>();
        }
    
        public int ID_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string Familia { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public Nullable<int> id_specialnosti { get; set; }
        public byte[] image { get; set; }
        public Nullable<int> Kabinet { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual Specialnosti Specialnosti { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zapisi> Zapisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zapisi> Zapisi1 { get; set; }
    }
}