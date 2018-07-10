using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kaf
{
    public class ItemGroup{
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int frontPosition { get; set; }
        public string frontPic { get; set; }
        public int picture { get; set; }
        public int color{ get; set; }
        public int type { get; set; }

        public virtual List<Item> items { get; set; }

        public override string ToString() {
            return name;
        }
    }

    public class ItemType {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public override string ToString() {
            return name;
        }
    }
    public class MeasureUnit {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString() {
            return name;
        }
    }
    public class Item {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public ItemGroup group { get; set; }
        public ItemType type { get; set; }
        public MeasureUnit measureUnit { get; set; }
        public int taxGroupId { get; set; }
        public decimal price { get; set; }
        public decimal price2 { get; set; }
        public int frontPosition { get; set; }
        public decimal vipPrice { get; set; }
        public bool izbacen { get; set; }
    }
}
