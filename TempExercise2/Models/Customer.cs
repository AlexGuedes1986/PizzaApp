using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempExercise2.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LicenseNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}