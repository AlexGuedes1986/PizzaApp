using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempExercise2.Models.ViewModels
{
    public class ToppingVM
    {
        public string SpecificTopping { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}