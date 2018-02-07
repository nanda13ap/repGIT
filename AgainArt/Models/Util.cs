using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AgainArt.Models
{
    public static class Util
    {
        public enum EnumPaintingType
        {
            [Display(Name = "Still Life")]// testar com outros
            StillLife = 1
                , Figures = 2
                , Landscape = 3
        }
        
    }
}