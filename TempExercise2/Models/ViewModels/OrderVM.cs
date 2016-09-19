using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempExercise2.Models.ViewModels
{
    public class OrderVM
    {        
        [ForeignKey("Customer")]
        public int LicenseNumber { get; set; }         
        public virtual Customer Customer { get; set; }
        public List<ToppingVM> Toppings { get; set; }
        public decimal TotalPrice { get; set; }
                                           // public bool IsSelected { get; set; }
    }
}