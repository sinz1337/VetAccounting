//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VetAccounting.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consumables
    {
        public int IdConsumables { get; set; }
        public string NameConsumables { get; set; }
        public string ManufacturerConsumables { get; set; }
        public string QuantityConsumables { get; set; }
        public string RemainsConsumables { get; set; }
        public System.DateTime DateOfReceiptConsumables { get; set; }
        public string ExpirationDateConsumables { get; set; }
        public byte[] PhotoConsumables { get; set; }
        public int IdStaff { get; set; }
        public string InfoConsumables { get; set; }
        public string SizeConsumables { get; set; }
    
        public virtual Staff Staff { get; set; }
    }
}
