//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pelipenko220
{
    using System;
    using System.Collections.Generic;
    
    public partial class ИнформацияОКниге
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ИнформацияОКниге()
        {
            this.ВыдачаКниги = new HashSet<ВыдачаКниги>();
            this.Авторы = new HashSet<Авторы>();
            this.Жанры = new HashSet<Жанры>();
        }
    
        public int ИнвентарныйНомер { get; set; }
        public string Название { get; set; }
        public int КодИздательства { get; set; }
        public int ГодИздания { get; set; }
        public int КолвоСтраниц { get; set; }
        public double Цена { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ВыдачаКниги> ВыдачаКниги { get; set; }
        public virtual Издательство Издательство { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Авторы> Авторы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Жанры> Жанры { get; set; }
    }
}
