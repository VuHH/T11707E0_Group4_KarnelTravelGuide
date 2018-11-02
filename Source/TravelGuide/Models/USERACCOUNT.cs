namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERACCOUNT")]
    public partial class USERACCOUNT
    {

        [Key]
        [StringLength(32)]
        public string ID_USER { get; set; }

        [Required]
        [StringLength(200)]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        public string NAME_USER { get; set; }


        [StringLength(200)]
        [Display(Name = "Address")]
        public string ADDRESS_USER { get; set; }

        [StringLength(10)]
        [Phone]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [Display(Name = "Phone")]
        public string TEL_USER { get; set; }

        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [Display(Name = "Email Address")]
        public string EMAIL_USER { get; set; }

        [Display(Name = "Disable")]
        public bool? DISASBLE { get; set; }

        [StringLength(50)]
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASS_USER { get; set; }


    }
}
