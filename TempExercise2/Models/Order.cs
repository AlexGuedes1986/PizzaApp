using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempExercise2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [ForeignKey("Customer")]        
        public int LicenseNumber { get; set; }
        public virtual Customer Customer { get; set; }
        public List<string> Toppings { get; set; }
        public decimal TotalPrice { get; set; }
    }
}