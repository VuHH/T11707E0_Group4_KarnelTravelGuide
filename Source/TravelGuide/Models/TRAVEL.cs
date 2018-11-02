namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRAVEL")]
    public partial class TRAVEL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id")]
        public int ID_TRAVEL { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string NAME_TRAVEL { get; set; }

        [StringLength(3)]
        [Display(Name = "Id City")]
        public string ID_CITY { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_TRAVEL { get; set; }

        [StringLength(10)]
        [MinLength(10), MaxLength(11)]
        [Display(Name = "Telephone")]
        public string TEL_TRAVEL { get; set; }

        [Display(Name = "Quality")]
        [Range(0, 10)]
        public int? QUALITY_TRAVEL { get; set; }

        [Display(Name = "Available")]
        public bool? AVAILABLE { get; set; }

        [Display(Name = "Description")]
        [StringLength(1000)]
        public string DES_TRAVEL { get; set; }

        [Display(Name = "Introduction")]
        [StringLength(200)]
        public string INTRODUCE_TRAVEL { get; set; }

        [StringLength(200)]
        [Display(Name = "Image")]
        public string IMAGE_TRAVEL { get; set; }

        [Display(Name = "Discounted")]
        public bool? ISDISCOUNT_TRAVEL { get; set; }

        [Display(Name = "Discount")]
        public int? DISCOUNT_TRAVEL { get; set; }

        public virtual CITY CITY { get; set; }

        [StringLength(200)]
        public string IMAGE_DETAIL_TRAVEL { get; set; }
    }
}
