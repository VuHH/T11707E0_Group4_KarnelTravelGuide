namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOTEL")]
    public partial class HOTEL
    {
        [Key]
        [Display(Name = "Id Hotel")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HOTEL { get; set; }

        [Required]
        [Display(Name = "Name Hotel")]
        [StringLength(200)]
        public string NAME_HOTEL { get; set; }

        [StringLength(3)]
        [Display(Name = "Id City")]
        public string ID_CITY { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_HOTEL { get; set; }

        [StringLength(10)]
        [Display(Name = "Telephone")]
        [MinLength(10), MaxLength(11)]
        public string TEL_HOTEL { get; set; }

        [Display(Name = "Quality")]
        [Range(0, 10)]
        public int? QUALITY_HOTEL { get; set; }

        [StringLength(200)]
        [Display(Name = "Introduction")]
        public string INTRODUCE_HOTEL { get; set; }

        [StringLength(1000)]
        [Display(Name = "Description")]
        public string DES_HOTEL { get; set; }

        [StringLength(200)]
        [Display(Name = "Image")]
        public string IMAGE_HOTEL { get; set; }

        [Display(Name = "Available")]
        public bool? AVAILABLE { get; set; }

        public virtual CITY CITY { get; set; }

        [Display(Name = "Price")]
        public int? PRICE_HOTEL { get; set; }

        [Display(Name = "Discounted")]
        public bool? ISDISCOUNT_HOTEL { get; set; }

        [Display(Name = "Discount")]
        public int? DISCOUNT_HOTEL { get; set; }


        [StringLength(200)]
        public string IMAGE_DETAIL_HOTEL { get; set; }

    }
}
