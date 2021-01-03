using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KnxDataCollector.Models
{
    public partial class KnxDBContext : DbContext
    {
        //public KnxDBContext()
        //{
        //}

        public KnxDBContext(DbContextOptions<KnxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RawLogs> RawLogs { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=185.79.243.30;Initial Catalog=KnxDB;User ID=SA;Password=matikubaK1617!");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RawLogs>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__RawLogs__5E548648AC392246");

                entity.Property(e => e.FrameFormat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogTimestamp).HasColumnType("datetime");

                entity.Property(e => e.RawData)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
