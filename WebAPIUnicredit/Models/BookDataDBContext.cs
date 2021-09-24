using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUnicredit.Models
{
    public class BookDataDBContext:DbContext
    {
        public BookDataDBContext(DbContextOptions<BookDataDBContext> options):base(options)
        {

        }
        public DbSet<BookInstance> BookInstances { get; set; }
    }
}
