namespace TravelGuide
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TravelGuideDBContext : DbContext
    {
        public TravelGuideDBContext()
            : base("name=TravelGuideDBContext")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CITY> CITies { get; set; }
        public virtual DbSet<COMMENT> COMMENTs { get; set; }
        public virtual DbSet<HOTEL> HOTELs { get; set; }
        public virtual DbSet<RESORT> RESORTs { get; set; }
        public virtual DbSet<RESTAURANT> RESTAURANTs { get; set; }
        public virtual DbSet<TOURIST_SPOTS> TOURIST_SPOTS { get; set; }
        public virtual DbSet<TRAVEL> TRAVELs { get; set; }
        public virtual DbSet<USERACCOUNT> USERACCOUNTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.NAME_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.ADDRESS_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TEL_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.EMAIL_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.PASS_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<CITY>()
                .Property(e => e.ID_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<CITY>()
                .Property(e => e.NAME_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<COMMENT>()
                .Property(e => e.CONTENT_COMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<COMMENT>()
                .Property(e => e.ID_REPLY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMMENT>()
                .Property(e => e.ID_COMMENT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMMENT>()
                .Property(e => e.ID_USER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.NAME_HOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.ID_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.ADDRESS_HOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.TEL_HOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.INTRODUCE_HOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.DES_HOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.IMAGE_HOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<RESORT>()
                .Property(e => e.NAME_RESORT)
                .IsUnicode(false);

            modelBuilder.Entity<RESORT>()
                .Property(e => e.ID_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<RESORT>()
                .Property(e => e.ADDRESS_RESORT)
                .IsUnicode(false);

            modelBuilder.Entity<RESORT>()
                .Property(e => e.TEL_RESORT)
                .IsUnicode(false);

            modelBuilder.Entity<RESORT>()
                .Property(e => e.INTRODUCE_RESORT)
                .IsFixedLength();

            modelBuilder.Entity<RESORT>()
                .Property(e => e.DES_RESORT)
                .IsUnicode(false);

            modelBuilder.Entity<RESORT>()
                .Property(e => e.IMAGE_RESORT)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.NAME_RESTAURANT)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.ID_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.ADDRESS_RESTAURANT)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.TEL_RESTAURANT)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.DES_RESTAURANT)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.INTRODUCE_RESTAURANT)
                .IsUnicode(false);

            modelBuilder.Entity<RESTAURANT>()
                .Property(e => e.IMAGE_RESTAURANT)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.NAME_TOURISTSPOT)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.ID_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.ADDRESS_TOURISTSPOT)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.TEL_TOURISTSPOT)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.DES_TOURIST_SPOTS)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.INTRODUCE_TOURIST_SPOTS)
                .IsUnicode(false);

            modelBuilder.Entity<TOURIST_SPOTS>()
                .Property(e => e.IMAGE_TOURIST_SPOTS)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.NAME_TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.ID_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.ADDRESS_TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.TEL_TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.DES_TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.INTRODUCE_TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TRAVEL>()
                .Property(e => e.IMAGE_TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCOUNT>()
                .Property(e => e.NAME_USER)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCOUNT>()
                .Property(e => e.ADDRESS_USER)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCOUNT>()
                .Property(e => e.TEL_USER)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCOUNT>()
                .Property(e => e.EMAIL_USER)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCOUNT>()
                .Property(e => e.PASS_USER)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCOUNT>()
                .Property(e => e.ID_USER)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
