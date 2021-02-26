using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KnxDataCollector.Model
{
    public partial class KnxDBContext : DbContext
    {

        public KnxDBContext(DbContextOptions<KnxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DecodedTelegrams> DecodedTelegrams { get; set; }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<KnxGroupAddresses> KnxGroupAddresses { get; set; }
        public virtual DbSet<KnxProcesses> KnxProcesses { get; set; }
        public virtual DbSet<KnxTelegrams> KnxTelegrams { get; set; }
        public virtual DbSet<RawLogs> RawLogs { get; set; }
        public virtual DbSet<XmlFiles> XmlFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DecodedTelegrams>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataFloat).HasColumnType("float");

                entity.Property(e => e.GroupAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FrameFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerializedData).HasColumnType("xml");

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("date");

                entity.Property(e => e.TimestampS)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HomeText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<KnxGroupAddresses>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.Property(e => e.Gid).ValueGeneratedOnAdd();

                entity.Property(e => e.Central).HasMaxLength(50);

                entity.Property(e => e.Clutch).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(200);

                entity.Property(e => e.GroupAddress).HasMaxLength(50);

                entity.Property(e => e.Length).HasMaxLength(50);
            });

            modelBuilder.Entity<KnxProcesses>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.ProcessIp)
                    .IsRequired()
                    .HasColumnName("ProcessIP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedFile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KnxTelegrams>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Processed).HasColumnName("Processed");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrameFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RawData)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("date");

                entity.Property(e => e.TimestampS)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

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

            modelBuilder.Entity<XmlFiles>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_XMLFiles_1");

                entity.ToTable("XMLFiles");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsProcessed).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingPercentage).HasDefaultValueSql("((0))");

                entity.Property(e => e.Xmldata)
                    .IsRequired()
                    .HasColumnName("XMLData")
                    .HasColumnType("xml");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
