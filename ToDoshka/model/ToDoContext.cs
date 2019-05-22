using System.Data.Entity;

namespace ToDoshka.Model
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
            : base("name=ToDoshkaEntities")
        {
        }
        
        public DbSet<Attachments> attachments { get; set; }
        public DbSet<Subtasks> subtasks { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subtasks>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.Subtasks)
                .HasForeignKey(e => e.SubtaskID);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.Tasks)
                .HasForeignKey(e => e.TaskID);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.Subtasks)
                .WithOptional(e => e.Tasks)
                .HasForeignKey(e => e.TaskID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
