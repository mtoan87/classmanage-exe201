using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAO.Models
{
    public partial class ManageCourseContext : DbContext
    {
        public ManageCourseContext()
        {
        }

        public ManageCourseContext(DbContextOptions<ManageCourseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<ChildrenClass> ChildrenClasses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassTime> ClassTimes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=1234567890;Database=ManageCourse");
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
                    .HasConstraintName("FK__AcademicT__child__5441852A");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__cours__534D60F1");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__teach__52593CB8");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__parent_id__5EBF139D");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__cart_i__619B8048");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__childr__6477ECF3");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__class___6383C8BA");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__course__628FA481");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("img_url");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("username");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Children__parent__4BAC3F29");
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
                    .HasConstraintName("FK__ChildrenC__child__72C60C4A");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ChildrenClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChildrenC__class__71D1E811");
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
                    .HasConstraintName("FK__Class__course_id__5AEE82B9");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__teacher_i__5BE2A6F2");
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
                    .HasConstraintName("FK__ClassTime__class__6754599E");
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
                    .HasConstraintName("FK__Feedback__childr__75A278F5");
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

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

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

                entity.Property(e => e.ImgUrl).HasColumnName("img_url");

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

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.PaidTime)
                    .HasColumnType("datetime")
                    .HasColumnName("paid_time");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__cart_id__7B5B524B");
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
                    .HasConstraintName("FK__TimeTable__child__6E01572D");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__class__6EF57B66");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__cours__6D0D32F4");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeTable__teach__6C190EBB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
