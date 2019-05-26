using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProject1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string PTitle { get; set; }
        public string PDescription { get; set; }
        public string PColor { get; set; }
        public string PSize { get; set; }
        public string PCategory{ get; set; }
        public string PStatus { get; set; }
        public double PPrice { get; set; }
    }
}