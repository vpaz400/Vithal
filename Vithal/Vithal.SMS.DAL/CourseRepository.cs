using Microsoft.EntityFrameworkCore;
using Vithal.Framework.Core;
using Vithal.SMS.Models;

namespace Vithal.SMS.DAL
{
    public class CourseRepository : BaseRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(DbContext context): base(context)
        {

        }
    }
}
