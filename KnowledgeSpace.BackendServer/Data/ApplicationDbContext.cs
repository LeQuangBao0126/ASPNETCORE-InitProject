using KnowledgeSpace.BackendServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeSpace.BackendServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //viet nhung cai custom thuoc tinh bang .. vd custom cac khoa chinh trong bảng


        public DbSet<Category> Categories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<CommandInFunction> CommandInFunctions { get; set; }
        public DbSet<KnowledgeBase> KnowledgeBases { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelInKnowledgeBase> LabelInKnowledgeBases { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Report> Reports { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //cau hình fluent api   để migration tốt hơn
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<User>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            // cau hinh cac  composite  key 
            builder.Entity<Permission>().HasKey(x => new { x.FunctionId, x.CommandId, x.RoleId });
            builder.Entity<Vote>().HasKey(x => new { x.KnowledgeBaseId , x.UserId });
            builder.Entity<CommandInFunction>().HasKey(x => new { x.CommandId , x.FunctionId});
            builder.Entity<LabelInKnowledgeBase>().HasKey(x => new { x.LabelId ,x.KnowledgeBaseId });
            // có thể có nhiều sequence 
            //con trol cái id tiếp theo => mỗi lần gọi nó cứ tăng lên 1
            builder.HasSequence("KnowledgeBaseSequence");
            //
            //
            // Có thể seeding data dưới này luôn . builder.entity<>.HasData()


        }
    }
}
