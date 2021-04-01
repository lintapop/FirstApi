using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FirstApi.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=Auction")
        {
        }

        public virtual DbSet<User> Users
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}