namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id Admin")]
        public int ID_ADMIN { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(200)]
        public string NAME_ADMIN { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_ADMIN { get; set; }

        [Required(ErrorMessage = "Phone Number Required!")]
        [MinLength(10), MaxLength(11)]
        [Display(Name = "Telephone")]
        [StringLength(11)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string TEL_ADMIN { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [StringLength(50)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EMAIL_ADMIN { get; set; }

        public bool? DISASBLE { get; set; }

        [StringLength(50)]
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASS_ADMIN { get; set; }
    }
}
