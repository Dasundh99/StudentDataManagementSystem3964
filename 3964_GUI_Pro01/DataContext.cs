using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3964_GUI_Pro01
{
    public class DataContext : DbContext
    {
        internal object selectedImage;
        internal object Images;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = StudentData.db");
        }

        public DbSet<Student> Students { get; set; }
    }
}
