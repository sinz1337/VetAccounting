using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetAccounting.DataFolder;

namespace VetAccounting.ClassFolder
{
    internal class GVClass
    {
        public static Consumables Consumables { get; set; }
        public static Medicines Medicines { get; set; }
        public static Purchase Purchase { get; set; }
        public static Role Role { get; set; }
        public static Staff Staff { get; set; }
        public static sysdiagrams sysdiagrams { get; set; }
        public static User User { get; set; }
        public static InfoConsumables InfoConsumables { get; set; }
        public static InfoMedicines InfoMedicines { get; set; }
    }
}
