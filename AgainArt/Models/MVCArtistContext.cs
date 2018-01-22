using System.Data.Entity;


namespace AgainArt.Models
{
    public class MVCArtistContext : DbContext
    {
        public MVCArtistContext():base("name=MVCArtistContext")
        {

        }

        public virtual DbSet<Artist> Artista { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
       
       /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./video_games.sqlite");
        }
        */
       
    }
}
