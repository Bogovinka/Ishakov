//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ishakov
{
    using System;
    using System.Collections.Generic;
    
    public partial class Scheclude
    {
        public int ID { get; set; }
        public Nullable<int> Days_id { get; set; }
        public Nullable<int> Items_id { get; set; }
        public Nullable<int> Step_lesson { get; set; }
    
        public virtual Days Days { get; set; }
        public virtual Items Items { get; set; }
    }
}
