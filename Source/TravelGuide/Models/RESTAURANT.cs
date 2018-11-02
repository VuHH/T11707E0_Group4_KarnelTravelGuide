namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESTAURANT")]
    public partial class RESTAURANT
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id")]
        public int ID_RESTAURANT { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string NAME_RESTAURANT { get; set; }

        [StringLength(3)]
        [Display(Name = "Id City")]
        public string ID_CITY { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_RESTAURANT { get; set; }

        [MinLength(10), MaxLength(11)]
        [StringLength(10)]
        [Display(Name = "Telephone")]
        public string TEL_RESTAURANT { get; set; }

        [Display(Name = "Quality")]
        [Range(0, 10)]
        public int? QUALITY_RESTAURANT { get; set; }

        [Display(Name = "Available")]
        public bool? AVAILABLE { get; set; }

        [StringLength(1000)]
        [Display(Name = "Description")]
        public string DES_RESTAURANT { get; set; }

        [StringLength(200)]
        [Display(Name = "Introduction")]
        public string INTRODUCE_RESTAURANT { get; set; }

        [StringLength(200)]
        [Display(Name = "Image")]
        public string IMAGE_RESTAURANT { get; set; }

        [Display(Name = "Discounted")]
        public bool? ISDISCOUNT_RES { get; set; }

        [Display(Name = "Discount")]
        public int? DISCOUNT_RES { get; set; }

        [Display(Name = "Price")]
        public int? PRICE_RESTAURANT { get; set; }

        public virtual CITY CITY { get; set; }

        [StringLength(200)]
        public string IMAGE_DETAIL_RESTAURANT { get; set; }
    }
}
