namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TOURIST_SPOTS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id")]
        public int ID_TOURISTSPOT { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string NAME_TOURISTSPOT { get; set; }

        [StringLength(3)]
        [Display(Name = "Id City")]
        public string ID_CITY { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_TOURISTSPOT { get; set; }

        [StringLength(10)]
        [Display(Name = "Telephone")]
        [MinLength(10), MaxLength(11)]
        public string TEL_TOURISTSPOT { get; set; }

        [Display(Name = "Quality")]
        [Range(0, 10)]
        public int? QUALITY_TOURISTSPOT { get; set; }

        [StringLength(1000)]
        [Display(Name = "Description")]
        public string DES_TOURIST_SPOTS { get; set; }

        [StringLength(200)]
        [Display(Name = "Introduction")]
        public string INTRODUCE_TOURIST_SPOTS { get; set; }

        [StringLength(200)]
        [Display(Name = "Image")]
        public string IMAGE_TOURIST_SPOTS { get; set; }

        public virtual CITY CITY { get; set; }

        [StringLength(200)]
        public string IMAGE_DETAIL_TOURIST_SPOTS { get; set; }
    }
}
