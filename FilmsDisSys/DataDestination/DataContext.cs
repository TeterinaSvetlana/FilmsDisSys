using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmsDisSys.DataDestination
{
    using Converter;    
    class DataContext : DbContext
    {
        protected DataContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }

        public DbSet<Films> Films { get; set; }

        public DbSet<Directors> Directors { get; set; }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<Tags> Tags { get; set; }

        public DbSet<Typess> Typess { get; set; }

        public DbSet<TagsFilms> TagsFilms { get; set; }
    }
}
