//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFForBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryOfNews
    {
        public int IdRecord { get; set; }
        public int IdNews { get; set; }
        public int IdCategory { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual News News { get; set; }
    }
}
