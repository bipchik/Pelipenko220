//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pelipenko220
{
    using System;
    using System.Collections.Generic;
    
    public partial class Авторы
    {
        public Авторы()
        {
            this.ИнформацияОКниге = new HashSet<ИнформацияОКниге>();
        }
    
        public int КодАвтора { get; set; }
        public string ФИО { get; set; }
    
        public virtual ICollection<ИнформацияОКниге> ИнформацияОКниге { get; set; }
    }
}
