using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAO.Models
{
    public partial class ManageCourseCenterContext : DbContext
    {
        public ManageCourseCenterContext()
        {
        }

        public ManageCourseCenterContext(DbContextOptions<ManageCourseCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<ChildrenClass> ChildrenClasses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassTime> ClassTimes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=1234567890;database=ManageCourseCenter;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AcademicTranscript>(entity =>
            {
                entity.ToTable("AcademicTranscript");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Average)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("average");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Final)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("final");

                entity.Property(e => e.Midterm)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("midterm");

                entity.Property(e => e.Quiz1)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("quiz_1");

                entity.Property(e => e.Quiz2)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("quiz_2");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__child__5165187F");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__cours__5070F446");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__teach__4F7CD00D");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("img_url");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ChildrenClass>(entity =>
            {
                entity.ToTable("ChildrenClass");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.ChildrenClasses)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChildrenC__child__6754599E");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ChildrenClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChildrenC__class__66603565");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__course_id__5812160E");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__teacher_i__59063A47");
            });

            modelBuilder.Entity<ClassTime>(entity =>
            {
                entity.ToTable("ClassTime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.DayInWeek)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("day_in_week");

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("end_time");

                entity.Property(e => e.StarTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("star_time");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassTimes)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassTime__class__5BE2A6F2");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseFormTime)
                    .HasColumnType("datetime")
                    .HasColumnName("close_form_time");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("img_url");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OpenFormTime)
                    .HasColumnType("datetime")
                    .HasColumnName("open_form_time");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalSlot).HasColumnName("total_slot");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildrenClassId).HasColumnName("children_class_id");

                entity.Property(e => e.CourseRating).HasColumnName("course_rating");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EquipmentRating).HasColumnName("equipment_rating");

                entity.Property(e => e.TeacherRating).HasColumnName("teacher_rating");

                entity.HasOne(d => d.ChildrenClass)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ChildrenClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__childr__6A30C649");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("img_url");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("img_url");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TimeTable>(entity =>
            {
                entity.ToTable("TimeTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.DayInWeek)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("day_in_week");

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("end_time");

                entity.Property(e => e.StarTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("star_time");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__child__628FA481");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__class__6383C8BA");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__cours__619B8048");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__teach__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
