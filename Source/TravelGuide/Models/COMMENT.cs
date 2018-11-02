namespace TravelGuide
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMMENT")]
    public partial class COMMENT
    {
        [StringLength(1000)]
        public string CONTENT_COMMENT { get; set; }

        public int? ID_HOTEL { get; set; }

        public int? ID_RESTAURANT { get; set; }

        public int? ID_TRAVEL { get; set; }

        public int? ID_RESORT { get; set; }

        public int? ID_TOURISTSPOT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DT_COMMENT { get; set; }

        public bool? FLAG_REPLY { get; set; }

        [StringLength(32)]
        public string ID_REPLY { get; set; }

        [Key]
        [StringLength(32)]
        public string ID_COMMENT { get; set; }

        [StringLength(32)]
        public string ID_USER { get; set; }

        public virtual USERACCOUNT USERACCOUNT { get; set; }
    }
}
