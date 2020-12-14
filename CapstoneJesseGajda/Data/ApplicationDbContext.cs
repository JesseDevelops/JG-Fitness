using System;
using System.Collections.Generic;
using System.Text;
using CapstoneJesseGajda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CapstoneJesseGajda.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserBMI> UserBMI { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<ExerciseMetrics> ExerciseMetrics { get; set; }
        public DbSet<WorkoutList> WorkoutList { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }

    }
}
