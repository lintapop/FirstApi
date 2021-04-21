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

        public virtual DbSet<ArtistInfo> ArtistInfos
        {
            get; set;
        }

        public virtual DbSet<Bid> Bids
        {
            get; set;
        }

        public virtual DbSet<ProductImage> ProductImages
        {
            get; set;
        }

        public virtual DbSet<Product> Products
        {
            get; set;
        }

        public virtual DbSet<Genre> Genres
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<FirstApi.Models.ArtistInfoImage> ArtistInfoImages
        {
            get; set;
        }
    }
}