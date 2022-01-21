using Microsoft.EntityFrameworkCore;
using Vithal.SMS.Models;

namespace Vithal.SMS.DAL
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext(DbContextOptions<StudentDataContext> options) : base(options) { }

        public virtual DbSet<StudentEntity> Students { get; set; }
        public virtual DbSet<CourseEntity> Courses { get; set; }

    }
}
