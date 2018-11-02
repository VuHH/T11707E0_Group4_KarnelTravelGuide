using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelGuide.Models
{
    public class AdvanceSearchModel
    {
       public string city { get; set; }
       public bool isAvailable { get; set; }
        public int quality { get; set; }

        public int minPrice { get; set; }

        public int maxPrice { get; set; }

        public bool isDiscount { get; set; }

    }
}