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
    
    public partial class Пользователь
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пользователь()
        {
            this.ИнформацияОЧитателе = new HashSet<ИнформацияОЧитателе>();
        }
    
        public int КодПользователя { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string ФИО { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ИнформацияОЧитателе> ИнформацияОЧитателе { get; set; }
    }
}
