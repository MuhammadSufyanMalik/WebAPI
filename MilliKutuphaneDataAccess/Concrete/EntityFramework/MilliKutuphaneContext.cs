using Microsoft.EntityFrameworkCore;
using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class MilliKutuphaneContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<UserHistory> UserHistory { get; set; }
        public DbSet<UserQrCode> UserQrCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Add your dataBase Configuration.
            optionsBuilder.UseSqlServer(@"Server=localhost;user=yourUserName;Database=DataBaseName;Password=YourLocalHostPassword;Encrypt=false;TrustServerCertificate=False;  MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(e => e.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(e => e.Username).HasMaxLength(75).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(e => e.FirstName).HasMaxLength(75).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(e => e.LastName).HasMaxLength(75).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(e => e.IdentityNumber).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<User>().Property(e => e.TelephoneNumber).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<User>().Property(e => e.PasswordHash).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(e => e.PasswordSalt).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(e => e.Email).HasMaxLength(75).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(e => e.CreatedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>().Property(e => e.LastModifiedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>().Property(e => e.isDelete).IsRequired().HasDefaultValue(false);
         //   modelBuilder.Entity<User>().HasMany<UserHistory>(e=>e.UserHistories).WithOne(e => e.User);
            


            modelBuilder.Entity<Gate>().ToTable("Gates");
            modelBuilder.Entity<Gate>().HasKey(x => x.Id);
            modelBuilder.Entity<Gate>().Property(x => x.Id).IsRequired().UseIdentityColumn().ValueGeneratedOnAdd();
            modelBuilder.Entity<Gate>().Property(x => x.Name).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Gate>().Property(x => x.Description).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Gate>().Property(x => x.QrCode).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Gate>().Property(x => x.CreatedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Gate>().Property(x => x.LastModifiedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Gate>().Property(e => e.isDelete).IsRequired().HasDefaultValue(false);




            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.SchoolId).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Student>().Property(x => x.StudentNumber).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(x => x.Department).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Student>().Property(e => e.isDelete).IsRequired().HasDefaultValue(false);
            //modelBuilder.Entity<Student>().HasOne(x=>x.School).WithMany(x=>x.Students).HasForeignKey(x=>x.SchoolId).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Student>().HasOne(x=>x.School).WithMany(x=>x.Students).HasForeignKey(x=>x.SchoolId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().HasOne(x => x.User).WithOne(x => x.Student).HasForeignKey<Student>(x => x.Id).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Admin>().HasKey(x => x.Id);
            modelBuilder.Entity<Admin>().Property(x => x.Designation).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Admin>().Property(x => x.isDelete).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Admin>().HasOne(x => x.User).WithOne(x => x.Admin).HasForeignKey<Admin>(x => x.Id).OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<School>().ToTable("School");
            modelBuilder.Entity<School>().HasKey(e => e.Id);
            modelBuilder.Entity<School>().Property(e => e.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd();
            modelBuilder.Entity<School>().Property(e => e.SchoolName).HasMaxLength(200).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<School>().Property(e => e.SchoolTelephone).HasMaxLength(11).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<School>().Property(e => e.SchoolCity).HasMaxLength(50).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<School>().Property(e => e.SchoolCountry).HasMaxLength(50).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<School>().Property(e => e.SchoolZipCode).HasMaxLength(10).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<School>().Property(e => e.SchoolAddress).HasMaxLength(200).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<School>().Property(e => e.CreatedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<School>().Property(e => e.LastModifiedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<School>().Property(e => e.isDelete).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<School>().HasMany<Student>(e => e.Students).WithOne(e => e.School).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<UserHistory>().ToTable("UserHistory");
            modelBuilder.Entity<UserHistory>().HasKey(x => x.Id);
            modelBuilder.Entity<UserHistory>().Property(e => e.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd();
            modelBuilder.Entity<UserHistory>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<UserHistory>().Property(x => x.GateId).IsRequired();
            modelBuilder.Entity<UserHistory>().Property(x => x.PassageWayTime).IsRequired();
            modelBuilder.Entity<UserHistory>().Property(x => x.EntranceType).IsRequired().HasMaxLength(1);
            modelBuilder.Entity<UserHistory>().Property(e => e.CreatedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserHistory>().Property(e => e.LastModifiedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserHistory>().Property(e => e.isDelete).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<UserHistory>().HasOne(e => e.Gate).WithMany(e=> e.UserHistories).HasForeignKey(e=>e.GateId);
            modelBuilder.Entity<UserHistory>().HasOne(e => e.User).WithMany(e=> e.UserHistories).HasForeignKey(e=>e.UserId);

            modelBuilder.Entity<UserQrCode>().ToTable("UserQrCodes");
            modelBuilder.Entity<UserQrCode>().HasKey(e => e.Id);
            modelBuilder.Entity<UserQrCode>().Property(e => e.UserQrcode).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<UserQrCode>().Property(e => e.CreatedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserQrCode>().Property(e => e.LastModifiedTime).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserQrCode>().Property(e => e.isDelete).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<UserQrCode>().HasOne(e => e.User).WithOne(e => e.UserQrCode).HasForeignKey<UserQrCode>(e => e.Id).OnDelete(DeleteBehavior.Cascade);




            // modelBuilder.Entity<School>().HasData(new School() { Id = 1, SchoolName = "Sample School" });








            modelBuilder.Entity<User>().HasQueryFilter(x => x.isDelete == false);
            modelBuilder.Entity<Student>().HasQueryFilter(x => x.isDelete == false);
            modelBuilder.Entity<Gate>().HasQueryFilter(x => x.isDelete == false);
            modelBuilder.Entity<Admin>().HasQueryFilter(x => x.isDelete == false);
            modelBuilder.Entity<School>().HasQueryFilter(x => x.isDelete == false);
            modelBuilder.Entity<UserHistory>().HasQueryFilter(x => x.isDelete == false);
            modelBuilder.Entity<UserQrCode>().HasQueryFilter(x => x.isDelete == false);




            base.OnModelCreating(modelBuilder);
        }
    }
}
