using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProject1.Models
{
    public class Cart2
    {
        public int Cart2ID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemColor { get; set; }
        public string ItemSize { get; set; }
        public int ItemQuantity { get; set; }
    }
}