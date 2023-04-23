using Microsoft.EntityFrameworkCore;
using CMSApplication.Entities;
using CMSApplication.Identity;

namespace CMSApplication.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Donor> Donors { get; set; }    
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CharityHome> CharityHomes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<In_appMessaging> In_AppMessagings { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
