using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AttendenceApi.Models
{
    public partial class Student1Context : DbContext
    {
        

       public Student1Context(DbContextOptions<Student1Context> options)
            : base(options)
        {
        }

     

        public virtual DbSet<AttendeeRecords> AttendeeRecords { get; set; }
        public virtual DbSet<LoginRecords> LoginRecords { get; set; }
        public virtual DbSet<StudentRecords> StudentRecords { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Student1;Integrated Security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeRecords>(entity =>
            {
                entity.HasKey(e => e.Attnid);

                entity.ToTable("Attendee_Records");

                entity.Property(e => e.Attnid).ValueGeneratedNever();

                entity.Property(e => e.Attendence)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RollnoNavigation)
                    .WithMany(p => p.AttendeeRecords)
                    .HasForeignKey(d => d.Rollno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendee_Records_Student_Records");
            });

            modelBuilder.Entity<LoginRecords>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("Login_Records");

                entity.Property(e => e.Userid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentRecords>(entity =>
            {
                entity.HasKey(e => e.Rollno);

                entity.ToTable("Student_Records");

                entity.Property(e => e.Rollno).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Subject1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subject2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subject3)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
