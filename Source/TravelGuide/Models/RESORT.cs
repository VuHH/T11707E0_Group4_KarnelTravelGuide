namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESORT")]
    public partial class RESORT
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id Resort")]
        public int ID_RESORT { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string NAME_RESORT { get; set; }

        [StringLength(3)]
        [Display(Name = "Id City")]
        public string ID_CITY { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_RESORT { get; set; }

        [MinLength(10), MaxLength(11)]
        [StringLength(10)]
        [Display(Name = "Telephone")]
        public string TEL_RESORT { get; set; }

        [Range(0, 10)]
        [Display(Name = "Quality")]
        public int? QUALITY_RESORT { get; set; }

        [Display(Name = "Available")]
        public bool? AVAILABLE { get; set; }

        [StringLength(10)]
        [Display(Name = "Introduction")]
        public string INTRODUCE_RESORT { get; set; }

        [StringLength(1000)]
        [Display(Name = "Description")]
        public string DES_RESORT { get; set; }

        [StringLength(200)]
        [Display(Name = "Image")]
        public string IMAGE_RESORT { get; set; }

        [Display(Name = "Discounted")]
        public bool? ISDISCOUNT_RESORT { get; set; }

        [Display(Name = "Discount")]
        public int? DISCOUNT_RESORT { get; set; }

        [Display(Name = "Price")]
        public int? PRICE_RESORT { get; set; }

        public virtual CITY CITY { get; set; }

        [StringLength(200)]
        public string IMAGE_DETAIL_RESORT { get; set; }

    }
}
