using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Db
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext(DbContextOptions options) : base(options)
        {

        }
    }
}
