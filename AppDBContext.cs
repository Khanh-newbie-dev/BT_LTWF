using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;" +
                "Database=QuanlySinhVien;" +
                "Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Fluent API định nghĩa rõ quan hệ 1 - N
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Faculty)
                .WithMany(f => f.Students)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data cho Khoa để có sẵn dữ liệu test
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = 1, FacultyName = "Công nghệ Thông tin" },
                new Faculty { Id = 2, FacultyName = "Kinh tế - Tài chính" },
                new Faculty { Id = 3, FacultyName = "Ngôn ngữ Anh" }
            );
        }
    }
}
